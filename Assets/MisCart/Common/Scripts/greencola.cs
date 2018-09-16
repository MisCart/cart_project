using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MisCart;

public class greencola : MonoBehaviour {
    private GameObject cpu;
    private RaycastHit ground;
    private NavMeshAgent agent;
    bool flag=false;
    int rotate;
    int crash;
    int HP = 3;
    private GameObject fire;
 
    // Use this for initialization
    void Start () {
        rotate = 0;
        crash = 0;
        fire = gameObject.transform.Find("GroundExplode").gameObject;
        agent = GetComponent<NavMeshAgent>();
       
    }

	// Update is called once per frame
	void Update () {
        //ground = Physics.
        Vector3 move = transform.forward;
        agent.Move(move * Time.deltaTime * 150);
        if (flag == true)
        {
            if (rotate < 1080)
            {
                cpu.transform.Rotate(new Vector3(0,5,0));
                rotate += 5;
            }
            else
            {
                cpu.GetComponent<WaypointAgent>().enabled = true;
                rotate = 0;
                Destroy(gameObject);
            }
        }
        if (HP==0)
        {
            fire.SetActive(true);
            SoundController.PlaySE(Model.SE.bomb1);
            Invoke("Des",1);
        }
	}

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "CPU")
        {
            cpu = col.gameObject;
            fire.SetActive(true);
            SoundController.PlaySE(Model.SE.bomb1);
            cpu.GetComponent<CPUrotation>().startrotate();
            //col.gameObject.GetComponent<WaypointAgent>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(1).gameObject.SetActive(false);
            flag = true;
        }
        else
        {
            HP--;
        }
        crash++;
    }

    void Des()
    {
        Destroy(gameObject);
    }
}
