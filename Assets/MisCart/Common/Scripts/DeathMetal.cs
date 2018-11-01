using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MisCart;

public class DeathMetal : MonoBehaviour {
    private bool Death = false;
    [SerializeField]private GameObject DeathMetalObject;
    private GameObject mainCamera;
    // Use this for initialization
    void Start () {
        mainCamera = GameObject.Find("MainCamera");
	}

    public void SetDMO(GameObject gameObj)
    {
        DeathMetalObject = gameObj;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision col)
    {
        if (Death)
        {
            if (col.gameObject.tag == "CPU")
            {
                SoundController.PlaySE(Model.SE.bomb1);
                col.gameObject.GetComponent<CPUrotation>().startrotate();

            }
            else if(col.gameObject.tag == "Player")
            {
                SoundController.PlaySE(Model.SE.bomb1);
                col.gameObject.GetComponent<CPUrotation>().startrotate();

            }
        }
    }

       public void DeathMetalStart()
    {
        if (Death == false)
        {
            DeathMetalObject.SetActive(true);
            mainCamera.GetComponent<AudioSource>().volume = 0.05f;
            if (!GameData.isFinish)
            {
                SoundController.PlayBGM(Model.BGM.deathmetal2);
            }
           
            if (gameObject.transform.tag == "Player")
            {
                CameraPlay.Shockwave();
                Invoke("ShockW", 1f);
                Invoke("ShockW", 2f);
                Invoke("ShockW", 3f);
                Invoke("ShockW", 4f);
                Invoke("ShockW", 5f);
                Invoke("ShockW", 6f);
            }
            
            Invoke("DeathMetalEnd", 7f);
            Death = true;
        }
        
    }

    private void ShockW()
    {
        CameraPlay.Shockwave();
    }

    private void DeathMetalEnd()
    {
        Death = false;
        DeathMetalObject.SetActive(false);
        if (!GameData.isFinish)
        {
            mainCamera.GetComponent<AudioSource>().volume = 1.0f;
        }
        
        SoundController.StopBGM(Model.BGM.deathmetal2);
        if (gameObject.tag == "Player")
        {
            GetComponent<itemsystem>().SpecialOff();
        }
        else if (gameObject.tag == "CPU")
        {
            GetComponent<itemsystemforCPU>().SpecialOff();
        }
    }
}
