using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class itemsystemforCPU : MonoBehaviour
{
    int itemnum = 0;
    [SerializeField]
    private float colaspeed;
    public Transform itempos;
    public Transform itempos2;
    public GameObject gcolaitem;
    public GameObject rcolaitem;
    [SerializeField] private GameObject codeitem;

    GameObject nearestCPU;
    AudioSource audio3;
    AudioSource audio4;
    bool gcola = false;
    bool rcola = false;

    bool code = false;

    GameObject[] tagobjs;
    float mindis = 1000;
    // Use this for initialization
    void Start()
    {
        tagobjs = GameObject.FindGameObjectsWithTag("CPU");
        
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audio3 = audioSources[0];
        audio4 = audioSources[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (gcola == true)
        {
            audio3.PlayOneShot(audio3.clip);
            GameObject bullet = GameObject.Instantiate(gcolaitem) as GameObject;
            Vector3 force;
            force = this.gameObject.transform.forward * colaspeed;
            bullet.transform.position = itempos.position;
            bullet.GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);

            gcola = false;
        }
       
        if (rcola == true)
        {
            audio3.PlayOneShot(audio3.clip);
            GameObject bullet = GameObject.Instantiate(rcolaitem) as GameObject;
            Debug.Log(bullet.transform.position);
            bullet.transform.position = itempos.position;
            bullet.GetComponent<NavMeshAgent>().enabled = true;
            foreach (GameObject obj in tagobjs)
            {
                float dis = Vector3.Distance(transform.position, obj.transform.position);
                if (Vector3.Angle((obj.transform.position - transform.position).normalized, transform.forward) <= 90f)
                {
                    if (dis < mindis)
                    {
                        nearestCPU = obj;
                        mindis = dis;
                    }
                }
            }
            mindis = 1000;
            Debug.Log(nearestCPU);
            bullet.SendMessage("Settarget", nearestCPU);
            Vector3 force;
            force = this.gameObject.transform.forward * colaspeed;
            //bullet.transform.position = itempos.position;
            //bullet.GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);

            rcola = false;
        }
        if (code == true)
        {
            //audio4.PlayOneShot(audio4.clip);
            GameObject _code = GameObject.Instantiate(codeitem) as GameObject;
            _code.transform.position = itempos2.position;

            code = false;
        }






    }


    void OnTriggerEnter(Collider col)
    {
        if ((gcola == false) && (rcola == false)&& (code == false))
        {


            if (col.gameObject.tag == "item")
            {
                col.gameObject.SendMessage("itemcollision");
                Invoke("UseItem", Random.Range(1, 7));
               
            }
        }





     
    }

    void UseItem()
    {
        itemnum = Random.Range(1, 4);
        if (itemnum == 1)
        {
            gcola = true;
        }
        else if (itemnum == 2)
        {
            rcola = true;
        }

        else if (itemnum == 3)
        {
            code = true;
        }
        else if (itemnum == 5)
        {

        }
    }
}

