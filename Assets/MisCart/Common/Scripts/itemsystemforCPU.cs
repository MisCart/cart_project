using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsystemforCPU : MonoBehaviour
{
    int itemnum = 0;
    bool cola = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (cola == false)
        {


            if (col.gameObject.tag == "item")
            {
                col.gameObject.SendMessage("itemcollision");
                itemnum = 1; //Random.Range(0, 5);

                if (itemnum == 1)
                {
                    cola = true;
                }
                else if (itemnum == 2)
                {

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
}
