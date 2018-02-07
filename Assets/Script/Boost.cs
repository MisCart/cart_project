using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour {
    private Rigidbody car;
    public float bPower;
    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player"|| col.gameObject.tag == "CPU")
        {
            car = col.gameObject.GetComponent<Rigidbody>();
            float angleDir = car.transform.eulerAngles.y * (Mathf.PI / 180.0f);
            Vector3 dir = new Vector3(Mathf.Sin(angleDir), 0.0f, Mathf.Cos(angleDir));
            car.AddForce(dir * bPower,ForceMode.Impulse);
            Debug.Log("AddPower");
            //処理
        }
    }
}
