using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MisCart;

public class SlipItem : MonoBehaviour {
    // Use this for initialization
    private bool active = false;
	void Start () {

        Invoke("StartEffect", 1f);
    }
	
    private void StartEffect()
    {
        active = true;
    }
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Controller>().LimitCut();
                SoundController.PlaySE(Model.SE.encount1);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                Invoke("Dess", 2);
            }
            else if (other.gameObject.tag == "CPU")
            {
                other.gameObject.GetComponent<WaypointAgent>().LimitCut();
                SoundController.PlaySE(Model.SE.encount1);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                Invoke("Dess", 2);
            }
        }
    }
    void Dess()
    {
        Destroy(gameObject);
    }
}
