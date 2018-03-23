using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
 
    private Rigidbody car;
    private Vector3 power;
    public float jPower;
	// Use this for initialization
	void Start () {
       
        power =new Vector3 (0,jPower,0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player"||col.gameObject.tag == "CPU")
        {
            car = col.gameObject.GetComponent<Rigidbody>() ;
            car.AddForce(power, ForceMode.Impulse);
            Debug.Log("AddPower");
            //処理
        }
    }
}
