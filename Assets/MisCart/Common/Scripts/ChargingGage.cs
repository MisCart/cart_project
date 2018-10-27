using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChargingGage : MonoBehaviour {
    public Slider _slider;
    public float charging;
    private GameObject Player;
    [SerializeField] private float power = 1000f;
    [SerializeField] private GameObject boosttextobj;
    private Text boosttext;
    bool inval = false;
    float timer = 0f;
    private float rot = 360;
    private int color = 1;
    public  void SetPlayer(GameObject p)
    {
        Player = p;
    }
    // Use this for initialization
    void Start () {
        charging = _slider.value;
        boosttext = boosttextobj.GetComponent<Text>();
        //Player = GameObject.FindGameObjectWithTag("Player");
	}
    void Update()
    {
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
                inval = true;
                Invoke("Stay", 0.5f);

            }

        }
    }
    // Update is called once per frame
    void FixedUpdate () {

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

    void Stay()
    {
        inval = false;
    }
}
