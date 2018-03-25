using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemsystem : MonoBehaviour {
    int itemnum=0;
    [SerializeField]
    private float colaspeed;
    public Transform itempos;
    public GameObject gcolaitem;
    public GameObject rcolaitem;
    public GameObject itemtext;
    bool gcola = false;
    bool rcola=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.Space))||(Input.GetKeyDown(KeyCode.Joystick1Button4)))
        {
            if (gcola == true)
            {
                GameObject bullet = GameObject.Instantiate(gcolaitem) as GameObject;
                Vector3 force;
                force = this.gameObject.transform.forward * colaspeed;
                bullet.transform.position = itempos.position;
                bullet.GetComponent<Rigidbody>().AddForce(force,ForceMode.VelocityChange);
               
                gcola = false;
            }
            if (rcola == true)
            {
                GameObject bullet = GameObject.Instantiate(rcolaitem) as GameObject;
                Debug.Log(UnityStandardAssets.Utility.rank.nearestCPU);
                bullet.SendMessage("Settarget",UnityStandardAssets.Utility.rank.nearestCPU);
                Vector3 force;
                force = this.gameObject.transform.forward * colaspeed;
                bullet.transform.position = itempos.position;
                bullet.GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);

                rcola = false;
            }
        }

        if (gcola == true)
        {
            itemtext.GetComponent<Text>().text = "Cola(G)";
        }else if (rcola == true)
        {
            itemtext.GetComponent<Text>().text = "Cola(R)";
        }
        else
        {
            itemtext.GetComponent<Text>().text = "";
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if ((gcola==false)&&(rcola==false))
        {


            if (col.gameObject.tag == "item")
            {
                col.gameObject.SendMessage("itemcollision");
                itemnum = Random.Range(1, 3);

                if (itemnum == 1)
                {
                    gcola = true;
                }
                else if (itemnum == 2)
                {
                    rcola=true;
                }
                else if (itemnum == 3)
                {

                }
                else if (itemnum == 4)
                {

                }
                else if (itemnum == 5)
                {

                }
            }
        }
    }

    void sellectitem()
    {

    }
}
