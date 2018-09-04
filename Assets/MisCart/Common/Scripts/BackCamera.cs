using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCamera : MonoBehaviour {
    [SerializeField] private GameObject backCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if ((Input.GetKey(KeyCode.Q))||(Input.GetKey(KeyCode.Joystick1Button4)))
        {
            backCamera.SetActive(true);//
        }
        else
        {
            backCamera.SetActive(false);
        }
    }
}
