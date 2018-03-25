using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redcola : MonoBehaviour {
    private GameObject cpu;
    private Rigidbody rigid;
    bool flag = false;
    int rotate;
    int crash;
    // Use this for initialization
    void Start () {
        rotate = 0;
        crash = 0;
        rigid = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(cpu.transform.position);
        Debug.Log(cpu.transform.position);
        rigid.AddForce(transform.forward, ForceMode.VelocityChange);
        if (flag == true)
        {
           
            if (rotate < 1080)
            {
                cpu.transform.Rotate(new Vector3(0, 5, 0));
                rotate += 5;
            }
            else
            {
                rotate = 0;
                cpu.GetComponent<WaypointAgent>().enabled = true;
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "CPU")
        {
            cpu = col.gameObject;
            col.gameObject.GetComponent<WaypointAgent>().enabled = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            flag = true;
        }
        crash++;
    }

    void Settarget(GameObject target)
    {
        cpu = target;
    }
}
