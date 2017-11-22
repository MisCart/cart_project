using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComCon : MonoBehaviour {
    public GameObject target;
    Vector3 targetPos;
    Vector3 targetRot;
    // Use this for initialization
    void Start () {
        targetPos = target.transform.position;
        targetRot = target.transform.rotation.eulerAngles;
        transform.position = targetPos + new Vector3(0, 2f, -5f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += target.transform.position - targetPos;//+ new Vector3(0,2f,-5f);
        targetPos = target.transform.position;
        targetRot = target.transform.rotation.eulerAngles - targetRot;
        transform.RotateAround(targetPos, Vector3.up, targetRot.y);
        targetRot = target.transform.rotation.eulerAngles;
    }
}
