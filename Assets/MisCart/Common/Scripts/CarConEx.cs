using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarConEx : MonoBehaviour {
    public WheelCollider[] WheelColliders = new WheelCollider[4];
    private float steering;
    private float accel=70f;
    private float footbrake;
    private float thrustTorque;
    private float maxTorque;
    int i;
    // Use this for initialization  float steering, float accel, float footbrake, 
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.Z))
        {
            thrustTorque = accel;
            for (i = 0; i < 4; i++)
            {
                WheelColliders[i].motorTorque = thrustTorque;
            }
        }
    }
}
