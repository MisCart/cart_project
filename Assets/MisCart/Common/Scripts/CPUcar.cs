using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUcar : MonoBehaviour {
    public GameObject targets;
    private int t;
    private int Dstart=21;
    private int Dend = 29;
	// Use this for initialization
	void Start () {
        t = 1;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("collisions");
        if (col.gameObject.tag == "waypoint")
        {
            
            targets.SendMessage("ChangeTarget");

            if (t == Dstart)
            {
                targets.SendMessage("ds");
            }
            if (t == Dend)
            {
                targets.SendMessage("de");
            }
            if (t == 69)
            {
                targets.SendMessage("reset");
            }
            Debug.Log(t);
            t++;
            //処理
        }
    }
}
