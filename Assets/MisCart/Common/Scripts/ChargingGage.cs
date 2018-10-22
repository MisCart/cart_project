using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargingGage : MonoBehaviour {
    public Slider _slider;
    public float charging;
    private GameObject Player;
    [SerializeField] private float power = 1000f;
    bool inval = false;
    float timer = 0f;
    public  void SetPlayer(GameObject p)
    {
        Player = p;
    }
    // Use this for initialization
    void Start () {
        charging = _slider.value;
        //Player = GameObject.FindGameObjectWithTag("Player");
	}
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.V))||(Input.GetAxis("RightTrigger") ==-1))
        {
            if (inval == false)
            {
                if (charging > 10)
                {
                    Player.GetComponent<Rigidbody>().AddForce(Player.transform.forward * power, ForceMode.VelocityChange);
                    CameraPlay.Radial(0.6f);
                    //CameraPlay.Glitch(4f);
                    gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
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
