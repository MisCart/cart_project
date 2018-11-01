using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mizusibuki : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CameraPlay.RainDrop_ON(0.5f);
            Invoke("removeRainDrop", 2f);
        }
    }

    private void removeRainDrop()
    {
        CameraPlay.RainDrop_OFF(2f);
    }
}
