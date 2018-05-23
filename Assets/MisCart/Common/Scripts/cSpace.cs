using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                cSystem.GetComponent<ChargingGage>().charging += 20;
                interval = true;
                Invoke("ReCharge",3f);
            }
            
        }
    }

    void ReCharge()
    {
        interval = false;
    }
}
