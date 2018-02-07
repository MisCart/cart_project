using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallReturn : MonoBehaviour {
    public GameObject posO;
    private Rigidbody rigid;
    private Vector3 startPos;
    bool flag = false;
    bool up1 = false;
    int t=0;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (flag == true)
        {
            if (rigid.transform.position.y <= posO.transform.position.y-20f)
            {
                rigid.velocity = new Vector3(0, 0, 0);
                startPos = rigid.transform.position;
                up1 = true;
                flag = false;
            }
        }
        if (up1 == true)
        {
            rigid.velocity = new Vector3(0, 0, 0);
            rigid.transform.position = Vector3.Lerp(rigid.transform.position,posO.transform.position,Time.deltaTime);
            t++;
            if (t >= 150)
            {
                flag = false;
                up1 = false;
                t = 0;
            }
        }
       
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player"|| col.gameObject.tag == "CPU")
        {
            rigid = col.GetComponent<Rigidbody>();
            //rigid.velocity = new Vector3(rigid.velocity.x/2,rigid.velocity.y/2,rigid.velocity.z/2);
            rigid.velocity = new Vector3(0,0,0);
            flag = true;
            Debug.Log("flagon");
        }
    }
}
