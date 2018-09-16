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


            }
        }
    }

       public void DeathMetalStart()
    {
        Death = true;
        DeathMetalObject.SetActive(true);
        mainCamera.GetComponent<AudioSource>().volume = 0.05f;
        SoundController.PlayBGM(Model.BGM.deathmetal2);
        Invoke("DeathMetalEnd", 7f);
    }

    private void DeathMetalEnd()
    {
        Death = false;
        DeathMetalObject.SetActive(false);
        mainCamera.GetComponent<AudioSource>().volume = 1.0f;
        SoundController.StopBGM(Model.BGM.deathmetal2);
        GetComponent<itemsystem>().SpecialOff();
    }
}
