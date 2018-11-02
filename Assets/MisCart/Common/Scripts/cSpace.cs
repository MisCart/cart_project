using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MisCart;

public class cSpace : MonoBehaviour {
    GameObject cSystem;
    private bool interval = false;
    
	// Use this for initialization
	void Start () {
		cSystem= GameObject.FindGameObjectWithTag("csys");
    }
	
	// Update is called once per frame
	

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (interval == false)
            {
                if (!GameData.isFinish)
                {
                    SoundController.PlaySE(Model.SE.charge);
                }

                cSystem.GetComponent<ChargingGage>().charging += 20;
                interval = true;
                Invoke("ReCharge",3f);
            }
            
        }else if (col.gameObject.tag == "CPU")
        {
            if (interval == false)
            {
                //SoundController.PlaySE(Model.SE.charge);
                col.gameObject.GetComponent<ChargiGageForCPU>().charging += 20;
                interval = true;
                Invoke("ReCharge", 0.5f);
            }
        }
    }

    void ReCharge()
    {
        interval = false;
    }
}
