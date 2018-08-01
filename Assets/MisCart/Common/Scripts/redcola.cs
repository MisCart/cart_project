using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class redcola : MonoBehaviour {
    private GameObject cpu;
    private Rigidbody rigid;
    bool flag = false;
    int rotate;
    int crash;
    private GameObject fire;
    // Use this for initialization
    void Start () {
        rotate = 0;
        crash = 0;
        rigid = GetComponent<Rigidbody>();
        fire = gameObject.transform.Find("GroundExplode").gameObject;
    }
	
	// Update is called once per frame
	void Update () {

        if (GetComponent<NavMeshAgent>().pathStatus != NavMeshPathStatus.PathInvalid)
        {
            //navMeshAgentの操作GetComponent<NavMeshAgent>().speed = 1;//このようにスクリプトからNavMeshのプロパティをいじれる。
            GetComponent<NavMeshAgent>().destination = cpu.transform.position;
            //GetComponent<NavMeshAgent>().speed = 1;
        }
       
        
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "CPU")
        {
            cpu = col.gameObject;
            //cpu.gameObject.GetComponent<WaypointAgent>().enabled = false;
            fire.SetActive(true);
            cpu.GetComponent<CPUrotation>().startrotate();
            //col.gameObject.GetComponent<WaypointAgent>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(1).gameObject.SetActive(false);
            flag = true;
        }
        crash++;
    }

    void Settarget(GameObject target)
    {
        cpu = target;
    }
}
