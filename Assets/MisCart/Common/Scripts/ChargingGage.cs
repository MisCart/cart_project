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
    bool isCounting = true;
    float timer = 0f;
    // Use this for initialization
    void Start () {
        charging = _slider.value;
        Player = GameObject.FindGameObjectWithTag("Player");
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

        if (isCounting)
        {
            isCounting = GameUI.GameUIManager.IsCounting();
            return;
        }

        if (charging > 0)
        {
            charging -= 0.05f;
        }else if (charging > 100)
        {
            charging = 100;
        }else if (charging < 0)
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
