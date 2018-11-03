using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MisCart;

public class greencola : MonoBehaviour {
    private GameObject cpu;
    private RaycastHit ground;
    private NavMeshAgent agent;
    private GameObject shotObject;
    bool flag=false;
    int rotate;
    int crash;
    int HP = 3;
    private GameObject fire;

    private bool kiemasu=false;
   
    // Use this for initialization
    void Start () {
        rotate = 0;
        crash = 0;
        fire = gameObject.transform.Find("GroundExplode").gameObject;
        agent = GetComponent<NavMeshAgent>();
        Invoke("Kieru", 2f);

    }

    private void Kieru()
    {
        kiemasu = true;
    }

	// Update is called once per frame
	void Update () {
        //ground = Physics.
        Vector3 move = transform.forward;
        if (agent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            agent.Move(move * Time.deltaTime * 150);
        }
        else
        {
            HP = 0;
        }

        if (kiemasu)
        {
            if (agent.velocity.magnitude < 20)
            {
                HP = 0;
            }
        }
        
        
        if (HP==0)
        {
            fire.SetActive(true);
            if (!GameData.isFinish)
            {
                SoundController.PlaySE(Model.SE.bomb1);
            }
            Invoke("Des",1);
        }
	}

    void OnCollisionEnter(Collision col)
    {
        
            if (col.gameObject.tag == "CPU")
            {
                if (col.gameObject != shotObject)
                {
                    cpu = col.gameObject;
                    fire.SetActive(true);
                    if (!GameData.isFinish)
                    {
                        SoundController.PlaySE(Model.SE.bomb1);
                    }
                    cpu.GetComponent<CPUrotation>().startrotate();
                    //col.gameObject.GetComponent<WaypointAgent>().enabled = false;
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
                    transform.GetChild(1).gameObject.SetActive(false);
                    flag = true;

                    Destroy(gameObject, 2f);
                }
            }
            else if(col.gameObject.tag=="Player")
            {
                if (col.gameObject != shotObject)
                {
                    cpu = col.gameObject;
                    fire.SetActive(true);
                    if (!GameData.isFinish)
                    {
                        SoundController.PlaySE(Model.SE.bomb1);
                    }
                    cpu.GetComponent<CPUrotation>().startrotate();
                    //col.gameObject.GetComponent<WaypointAgent>().enabled = false;
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
                    transform.GetChild(1).gameObject.SetActive(false);
                    flag = true;

                    Destroy(gameObject, 2f);
            }
        }
            crash++;
        
    }

    public void SetShot(GameObject shot)
    {
        shotObject = shot;
    }

    void Des()
    {
        Destroy(gameObject);
    }
}
