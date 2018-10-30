using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MisCart;

public class ChargingGage : MonoBehaviour {
    public Slider _slider;
    public float charging=100f;
    private GameObject Player;
    [SerializeField] private float power = 100f;
    [SerializeField] private GameObject boosttextobj;
    private Text boosttext;
    bool inval = false;
    float timer = 0f;
    private float rot = 360;
    private int color = 1;

    private bool DoneStartDash = false;
    private float StartdashTime=0;
    private bool sound1=false;
    
    public  void SetPlayer(GameObject p)
    {
        Player = p;
    }
    // Use this for initialization
    void Start () {
        boosttext = boosttextobj.GetComponent<Text>();
        //Player = GameObject.FindGameObjectWithTag("Player");
	}
    void Update()
    {
        if (!DoneStartDash)
        {
            if ((Input.GetKey(KeyCode.Z))|| (Input.GetKey(KeyCode.Joystick1Button1)) || (Input.GetKey(KeyCode.Joystick1Button13)))
            {
                StartdashTime++;
            }
        }

        //シーン遷移開始直後はIscountingが上手く取れないようなので0.5秒止めておく
        while (timer < 0.5f)
        {
            timer += Time.deltaTime;
            return;
        }

        //カウントダウンをしているときは動かないようにする
        if (GameUI.GameUIManager.IsCounting())
        {
            return;
        }

        if (!DoneStartDash)
        {
            if (StartdashTime >= 80)
            {
                Player.GetComponent<Rigidbody>().AddForce(Player.transform.forward * power*1.5f, ForceMode.VelocityChange);
                CameraPlay.Radial(0.6f);
                //CameraPlay.Glitch(4f);
                gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
                charging -= 30;


                DoneStartDash = true;
            }
            else
            {
                DoneStartDash = true;
            }

        }

        if ((Input.GetKeyDown(KeyCode.V))||(Input.GetAxis("RightTrigger") ==-1)||(Input.GetKey(KeyCode.Joystick1Button9)))
        {
            if (inval == false)
            {
                if (charging > 10)
                {
                    Player.GetComponent<Rigidbody>().AddForce(Player.transform.forward * power, ForceMode.VelocityChange);
                    CameraPlay.Radial(0.6f);
                    //CameraPlay.Glitch(4f);
                    gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);

                    
                    DOTween.To(
                    () => rot,          // 何を対象にするのか
                    rot => boosttextobj.transform.eulerAngles= new Vector3(0, 0,rot),   // 値の更新
                    0,                  // 最終的な値
                    1.0f                  // アニメーション時間
                    );


                    DOTween.To(
                    () => color,          // 何を対象にするのか
                    color => boosttext.color = new Color(color,0,0),   // 値の更新
                    0,                  // 最終的な値
                    2.0f                  // アニメーション時間
                    );
                    charging -= 10;
                }

                Invoke("EraseText", 1.0f);
                Invoke("Stay", 3.0f);
                inval = true;
            }

        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        if ((Input.GetKey(KeyCode.Z))|| (Input.GetKey(KeyCode.Joystick1Button1)) || (Input.GetKey(KeyCode.Joystick1Button13)))
        {        
                if (sound1 == false)
                {
                    //audio1.PlayOneShot(audio1.clip);
                    SoundController.PlaySE(Model.SE.EngineSound);
                    sound1 = true;
                }
        }

        if ((Input.GetKeyUp(KeyCode.Z))|| (Input.GetKeyUp(KeyCode.Joystick1Button1)) || (Input.GetKeyUp(KeyCode.Joystick1Button13)))
        {
            SoundController.StopSE(Model.SE.EngineSound);
            sound1 = false;

        }
        //シーン遷移開始直後はIscountingが上手く取れないようなので0.5秒止めておく
        while (timer < 0.5f)
        {
            timer += Time.deltaTime;
            return;
        }

        if (GameUI.GameUIManager.IsCounting()){
            return;
        }

        if (charging > 0)
        {
            charging -= 0.05f;
        }
        if (charging > 100)
        {
            charging = 100;
        }
        if (charging < 0)
        {
            charging = 0;
        }

        _slider.value = charging;
	}
    private void EraseText()
    {
        boosttext.text = "";
    }
    void Stay()
    {
        boosttext.text = "Boost !";
        inval = false;
    }
}
