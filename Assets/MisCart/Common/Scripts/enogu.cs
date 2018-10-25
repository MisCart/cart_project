using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enogu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("off",7f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void off()
    {
        gameObject.SetActive(false);
    }
}
