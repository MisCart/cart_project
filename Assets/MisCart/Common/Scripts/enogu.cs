using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enogu : MonoBehaviour {
    private bool kesu;
	// Use this for initialization
	void Start () {
        kesu = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (kesu)
        {
            Invoke("off", 5f);
            kesu = false;
        }
    }

    void off()
    {
        kesu = true;
        gameObject.SetActive(false);

    }
}
