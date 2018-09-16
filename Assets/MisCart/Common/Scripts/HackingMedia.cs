using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingMedia : MonoBehaviour {
    private bool Hack = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision col)
    {
        if (Hack == true)
        {
            if (col.gameObject.tag == "CPU")
            {
                
                if (col.gameObject.GetComponent<itemsystemforCPU>().GetItemHave(1))
                {
                    Debug.Log("Hacking "+ col.gameObject.GetComponent<itemsystemforCPU>().GetItemHave(1));
                    GetComponent<itemsystem>().SpecialOff();
                    gameObject.GetComponent<itemsystem>().GetOtherItem(1);
                }else if (col.gameObject.GetComponent<itemsystemforCPU>().GetItemHave(2))
                {
                    Debug.Log("Hacking " + col.gameObject.GetComponent<itemsystemforCPU>().GetItemHave(2));
                    GetComponent<itemsystem>().SpecialOff();
                    gameObject.GetComponent<itemsystem>().GetOtherItem(2);
                    Debug.Log("Item " + gameObject.GetComponent<itemsystem>().GetItemHave(2));
                }
                else if (col.gameObject.GetComponent<itemsystemforCPU>().GetItemHave(3))
                {
                    GetComponent<itemsystem>().SpecialOff();
                    gameObject.GetComponent<itemsystem>().GetOtherItem(3);
                }
                else if (col.gameObject.GetComponent<itemsystemforCPU>().GetItemHave(4))
                {
                    GetComponent<itemsystem>().SpecialOff();
                    gameObject.GetComponent<itemsystem>().GetOtherItem(4);
                }


                col.gameObject.GetComponent<itemsystemforCPU>().BeHacking();
            }
            else if (col.gameObject.tag == "Player")
            {

            }
        }
        
    }


    public void HackStart()
    {
        Hack = true;
        Invoke("HackEnd", 7f);
    }

    private void HackEnd()
    {
        Hack = false;
        GetComponent<itemsystem>().SpecialOff();
    }
}
