using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour {
    private int t;
    private  List<Transform> myList =new List<Transform>();
    public Rigidbody rigidbody;
    private float speed=50f;
    float limit = 58f;
    float lPower;

    // Use this for initialization
    void Start () {
 
        t = 0;
        foreach (Transform child in transform)
        {
            myList.Add(child);
            Debug.Log(child.transform.position);
        }
        lPower = speed;
    }
	
	// Update is called once per frame
	void Update () {
        if ((rigidbody.velocity.x) >= limit)
        {
            rigidbody.AddForce(new Vector3(-lPower, 0, 0));
        }
        if ((rigidbody.velocity.x) <= -limit)
        {
            rigidbody.AddForce(new Vector3(lPower, 0, 0));
        }
        if ((rigidbody.velocity.y) >= limit)
        {
            rigidbody.AddForce(new Vector3(0, -lPower, 0));
        }
        if ((rigidbody.velocity.y) <= -limit)
        {
            rigidbody.AddForce(new Vector3(0, lPower, 0));
        }
        if ((rigidbody.velocity.z) >= limit)
        {
            rigidbody.AddForce(new Vector3(0, 0, -lPower));
        }
        if ((rigidbody.velocity.z) <= -limit)
        {
            rigidbody.AddForce(new Vector3(0, 0, lPower));
        }

        rigidbody.transform.LookAt(myList[t].position);

       float angleDir = rigidbody.transform.eulerAngles.y * (Mathf.PI / 180.0f);
       Vector3 dir = new Vector3(Mathf.Sin(angleDir), 0.0f, Mathf.Cos(angleDir));
       rigidbody.AddForce(dir * speed, ForceMode.Acceleration);


        //if (Input.GetKey(KeyCode.Z))
        //{
        //    float angleDir = rigidbody.transform.eulerAngles.y * (Mathf.PI / 180.0f);
        //    Vector3 dir = new Vector3(Mathf.Sin(angleDir), 0.0f, Mathf.Cos(angleDir));
        //    rigidbody.AddForce(dir * speed, ForceMode.Acceleration);
        //}
        Debug.Log(t);
    }

    void ChangeTarget()
    {
        t++;
    }

    void ds()
    {
        speed = 35f;
    }

    void de()
    {
        speed = 50f;
    }

    void reset()
    {
        t = 0;
    }
}
