using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintDan : MonoBehaviour {
    [SerializeField] private GameObject paintB;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void PaintStart()
    {
        GameObject bullet = GameObject.Instantiate(paintB) as GameObject;
        Vector3 force;
        bullet.transform.position = transform.position+new Vector3(0,5,0);
        force = this.gameObject.transform.forward * 100;
        bullet.GetComponent<Rigidbody>().AddForce(force,ForceMode.VelocityChange);
        GetComponent<itemsystem>().SpecialOff();
    }
}
