using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class correctDirection : MonoBehaviour {
    private WaypointProgressTracker _wpt;
    private float correctPower;
    private Rigidbody rigid;
    [SerializeField] private float StartCorrectValue=20f;
	// Use this for initialization
	void Start () {
        _wpt = GetComponent<WaypointProgressTracker>();
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 tag=_wpt.target.position - transform.position;
        //Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
        if (rigid.velocity.magnitude >= StartCorrectValue)
        {
            correctPower = 1 - GetComponent<Rigidbody>().velocity.magnitude / GetComponent<Controller>().limit * GetComponent<Rigidbody>().mass / 5000;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tag), 0.05f * Mathf.Clamp(correctPower, 0, 1));
        }
        
    }
}
