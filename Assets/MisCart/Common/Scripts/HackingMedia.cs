using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MisCart;

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
                    SoundController.PlaySE(Model.SE.hacksuccess);
                    SoundController.StopSE(Model.SE.hacklong);
                    Debug.Log("Hacking "+ col.gameObject.GetComponent<itemsystemforCPU>().GetItemHave(1));
                    GetComponent<itemsystem>().SpecialOff();
                    gameObject.GetComponent<itemsystem>().GetOtherItem(1);
                }else if (col.gameObject.GetComponent<itemsystemforCPU>().GetItemHave(2))
                {
                    SoundController.PlaySE(Model.SE.hacksuccess);
                    SoundController.StopSE(Model.SE.hacklong);
                    Debug.Log("Hacking " + col.gameObject.GetComponent<itemsystemforCPU>().GetItemHave(2));
                    GetComponent<itemsystem>().SpecialOff();
                    gameObject.GetComponent<itemsystem>().GetOtherItem(2);
                    Debug.Log("Item " + gameObject.GetComponent<itemsystem>().GetItemHave(2));
                }
                else if (col.gameObject.GetComponent<itemsystemforCPU>().GetItemHave(3))
                {
                    SoundController.PlaySE(Model.SE.hacksuccess);
                    SoundController.StopSE(Model.SE.hacklong);
                    GetComponent<itemsystem>().SpecialOff();
                    gameObject.GetComponent<itemsystem>().GetOtherItem(3);
                }
                else if (col.gameObject.GetComponent<itemsystemforCPU>().GetItemHave(4))
                {
                    SoundController.PlaySE(Model.SE.hacksuccess);
                    SoundController.StopSE(Model.SE.hacklong);
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
        SoundController.PlaySE(Model.SE.hacklong);
        Invoke("HackEnd", 7f);
    }

    private void HackEnd()
    {
        Hack = false;
        SoundController.StopSE(Model.SE.hacklong);
        GetComponent<itemsystem>().SpecialOff();
    }
}
