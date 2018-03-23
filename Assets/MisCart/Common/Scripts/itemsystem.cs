using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsystem : MonoBehaviour {
    int itemnum=0;
    bool cola = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cola == true)
            {
                cola = false;
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (cola==false)
        {


            if (col.gameObject.tag == "item")
            {
                itemnum = Random.Range(0, 5);

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

    void sellectitem()
    {

    }
}
