using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muteki : MonoBehaviour {
    private bool flag = false;
    public GameObject itemtext;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (flag == true)
        {
            itemtext.GetComponent<Text>().text = "Muteki";
        }
        else
        {
            itemtext.GetComponent<Text>().text = "";
        }
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "CPU")
        {
            if (flag == true)
            {
                col.gameObject.SendMessage("startrotate");
            }
        }

    }

    void StartMuteki()
    {
       
        Controller.limit = 85f;
        Debug.Log(Controller.limit);
        flag = true;
    }

    void EndMuteki()
    {
        Controller.limit = 75f;
        Debug.Log(Controller.limit);
        flag = false;
    }
}
