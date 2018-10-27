using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MisCart;

public class redcola : MonoBehaviour {
    private GameObject cpu;
    private Rigidbody rigid;
    bool flag = false;
    int rotate;
    int crash;
    private GameObject fire;
    private AudioSource ex;

    private bool effectactive=false;

    private void startexp()
    {
        effectactive = true;
    }
    // Use this for initialization

    void Start () {
        rotate = 0;
        crash = 0;
        rigid = GetComponent<Rigidbody>();
        fire = gameObject.transform.Find("GroundExplode").gameObject;
        ex = GetComponent<AudioSource>();
        Invoke("startexp",0.3f);
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
        if (effectactive)
        {
            if (col.gameObject.tag == "CPU")
            {
                cpu = col.gameObject;
                fire.SetActive(true);
                SoundController.PlaySE(Model.SE.bomb1);
                cpu.GetComponent<CPUrotation>().startrotate();
                gameObject.GetComponent<BoxCollider>().enabled = false;
                transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
                transform.GetChild(1).gameObject.SetActive(false);
                flag = true;
            }else if (col.gameObject.tag == "Player")
            {
                cpu = col.gameObject;
                fire.SetActive(true);
                SoundController.PlaySE(Model.SE.bomb1);
                col.gameObject.GetComponent<CPUrotation>().startrotate();
                gameObject.GetComponent<BoxCollider>().enabled = false;
                transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
                transform.GetChild(1).gameObject.SetActive(false);
                flag = true;
            }
            crash++;
        }
    }

    void Settarget(GameObject target)
    {
        cpu = target;
    }
}
