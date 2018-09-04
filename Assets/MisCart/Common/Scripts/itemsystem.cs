using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class itemsystem : MonoBehaviour {
    int itemnum=0;
    [SerializeField]
    private float colaspeed;
    public Transform itempos;
    public Transform itempos2;
    public GameObject gcolaitem;
    public GameObject rcolaitem;
    [SerializeField]private GameObject codeitem;
   
    public GameObject itemtext;
    [SerializeField]private GameObject DVDimage;
    [SerializeField]private GameObject CDimage;
    [SerializeField] private GameObject Codeimage;
    GameObject nearestCPU;
    AudioSource audio3;
    AudioSource audio4;
    bool gcola = false;
    bool rcola=false;
    
    bool code = false;

    [SerializeField] private Animator mischan;

    private GameObject ItemSellecter;


    GameObject[] tagobjs;
    float mindis = 1000;
    // Use this for initialization
    void Start () {
        ItemSellecter = GameObject.Find("UI");
        tagobjs = GameObject.FindGameObjectsWithTag("CPU");
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audio3 = audioSources[2];
        audio4 = audioSources[3];
    }
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.Space))||(Input.GetKeyDown(KeyCode.Joystick1Button4)))
        {
            
            if (gcola == true)
            {
                mischan.Play("ItemUse1");
                audio3.PlayOneShot(audio3.clip);
                GameObject bullet = GameObject.Instantiate(gcolaitem) as GameObject;
                Vector3 force;
                force = this.gameObject.transform.forward * colaspeed;
                bullet.transform.position = itempos.position;
                bullet.transform.forward = transform.forward;
                bullet.GetComponent<NavMeshAgent>().enabled = true;
                //bullet.GetComponent<Rigidbody>().AddForce(force,ForceMode.VelocityChange);

                gcola = false;
            }

            if (rcola == true)
            {
                mischan.Play("ItemUse1");
                audio3.PlayOneShot(audio3.clip);
                GameObject bullet2 = GameObject.Instantiate(rcolaitem) as GameObject;
                //bullet.AddComponent<NavMeshAgent>();
                Vector3 force;
                force = this.gameObject.transform.forward * colaspeed;
                bullet2.transform.position = itempos.position;
                bullet2.GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);
                bullet2.GetComponent<NavMeshAgent>().enabled = true;
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

                if (mindis == 1000)
                {
                    nearestCPU = null;
                }
                mindis = 1000;
                Debug.Log(nearestCPU);

                bullet2.SendMessage("Settarget", nearestCPU);

                //bullet2.transform.position = itempos.position;
                //bullet2.GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);

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
    

        if (gcola == true)
        {
            //itemtext.GetComponent<Text>().text = "Cola(G)";
            CDimage.SetActive(true);
        }else if (rcola == true)
        {
            //itemtext.GetComponent<Text>().text = "Cola(R)";
            DVDimage.SetActive(true);
            
        }else if (code == true)
        {
            //itemtext.GetComponent<Text>().text = "Muteki";
            Codeimage.SetActive(true);
        }
        else
        {
            itemtext.GetComponent<Text>().text = "";
            DVDimage.SetActive(false);
            CDimage.SetActive(false);
            Codeimage.SetActive(false);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if ((gcola==false)&&(rcola==false)&&(code==false))
        {


            if (col.gameObject.tag == "item")
            {
                col.gameObject.SendMessage("itemcollision");
                itemnum = Random.Range(1, 3);
                ItemSellecter.GetComponent<ItemSellect>().SellectStart();

            }
        }
    }

    public void sellectitem()
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
