using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MisCart;

public class HackingMedia : MonoBehaviour {
    private bool Hack = false;
    private GameObject[] tagobjs;
    private itemsystemforCPU[] cpus;
    private itemsystem Player;
    private itemsystemforCPU thissystemCPU;
    private itemsystem thissystem;
	// Use this for initialization
	void Start () {
        tagobjs = GameObject.FindGameObjectsWithTag("CPU");
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<itemsystem>();
        for (int i = 0; i > tagobjs.Length; i++)
        {
            cpus[i] = tagobjs[i].GetComponent<itemsystemforCPU>();
        }

        if (gameObject.tag == "Player")
        {
            thissystem = GetComponent<itemsystem>();
        }else if (gameObject.tag == "CPU")
        {
            thissystemCPU = GetComponent<itemsystemforCPU>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    


    public void HackStart()
    {
        if (Hack == false)
        {
            SoundController.PlaySE(Model.SE.hacklong);
            if (gameObject.tag != "Player")
            {
                CameraPlay.Glitch(5f);
            }
            //CameraPlay.Glitch(5f);
            Invoke("HackEnd", 5f);
            Hack = true;
        }
        
    }

    private void HackEnd()
    {
        Hack = false;
        SoundController.PlaySE(Model.SE.hacksuccess);
        SoundController.StopSE(Model.SE.hacklong);
        
       
        if (gameObject.tag == "Player")
        {
            for (int i = 0; i > 8; i++)
            {
                cpus[i].BeHacking();
            }


            thissystem.SpecialOff();
            thissystem.GetOtherItem(Random.Range(1, 5));
        }
        else if (gameObject.tag=="CPU")
        {
            for(int i = 0; i > 8; i++)
            {
                if (tagobjs[i] != gameObject)
                {
                    cpus[i].BeHacking();
                }
            }

            Player.BeHacking();

        
            thissystemCPU.SpecialOff();
            thissystemCPU.GetOtherItem(Random.Range(1, 5));
        }
       
    }
}
