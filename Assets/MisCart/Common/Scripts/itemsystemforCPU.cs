﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MisCart;

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
    private SearchCarts SearchArea;

    GameObject nearestCPU;
    bool gcola = false;
    bool rcola = false;

    bool code = false;
    private bool special = false;

    GameObject[] tagobjs;
    float mindis = 1000;
    private bool useItem=false;

    private int CartType = 0;//1=pro,2=midi, 3=cd

    public void SetCartType(int i)
    {
        CartType = i;
    }

    public bool GetItemHave(int i)
    {
        if (i == 1)
        {
            return gcola;
        }else if (i == 2)
        {
            return rcola;
        }else if (i==3)
        {
            return code;
        }else 
        {
            return special;
        }
    }

    public void BeHacking()
    {
        gcola=false;
        rcola = false;
        code = false;
        special = false;
    }

    public void GetOtherItem(int i)
    {
        if (i == 1)
        {
            gcola = true;
        }
        else if (i == 2)
        {
            rcola = true;
        }
        else if (i == 3)
        {
            code = true;
        }
        else
        {
            special = true;
        }
    }

    public void SpecialOff()
    {
        special = false;
    }
    // Use this for initialization
    void Start()
    {
        tagobjs = GameObject.FindGameObjectsWithTag("CPU");
        SearchArea = gameObject.transform.Find("ItemSearchArea").gameObject.GetComponent<SearchCarts>();


    }

    // Update is called once per frame
    void Update()
    {
        if (SearchArea.GetInSearch())
        {


            if (gcola == true)
            {
                SoundController.PlaySE(Model.SE.アイテム投擲);
                GameObject bullet = GameObject.Instantiate(gcolaitem) as GameObject;
                Vector3 force;
                force = this.gameObject.transform.forward * colaspeed;
                bullet.transform.position = itempos.position;
                bullet.GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);

                gcola = false;
            }

            if (rcola == true)
            {
                SoundController.PlaySE(Model.SE.アイテム投擲);
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

                var player = GameObject.FindGameObjectWithTag("Player");
                float dis2 = Vector3.Distance(transform.position, player.transform.position);
                if (Vector3.Angle((player.transform.position - transform.position).normalized, transform.forward) <= 90f)
                {
                    if (dis2 < mindis)
                    {
                        nearestCPU = player;
                        mindis = dis2;
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
            
            if (special == true)
            {
                special = false;
            }
            useItem = false;
        }

        if (code == true)
        {
            SoundController.PlaySE(Model.SE.setup1);
            GameObject _code = GameObject.Instantiate(codeitem) as GameObject;
            _code.transform.position = itempos2.position;

            code = false;
            useItem = false;
        }





    }


    void OnTriggerEnter(Collider col)
    {
        if ((gcola == false) && (rcola == false)&& (code == false)&&(special==false))
        {


            if (col.gameObject.tag == "item")
            {
                col.gameObject.SendMessage("itemcollision");
                
                Invoke("SetUseItem", Random.Range(4, 10));
               
            }
        }





     
    }

    public void SetUseItem()
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
        else if (itemnum == 4)
        {
            special = true;
        }
    }
}

