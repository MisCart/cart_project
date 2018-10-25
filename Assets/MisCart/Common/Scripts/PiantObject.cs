using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiantObject : MonoBehaviour {
    GameObject PgameObject;
    public int sw = 0;
	// Use this for initialization
    public void Setsw(int i)
    {
        sw = i;
    }
	void Start () {
        PgameObject = GameObject.Find("UI/Canvas/enogu");
        Invoke("NOTN", 20f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(sw);
        if (other.gameObject.tag == "Player")
        {
            if (sw != 1)
            {
                if (PgameObject.activeSelf == false)
                {
                    PgameObject.SetActive(true);
                }
                other.GetComponent<Controller>().LimitCut();
                other.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
            }

        }
        else if (other.gameObject.tag == "CPU")
        {
            other.GetComponent<WaypointAgent>().LimitCut();
            other.gameObject.transform.GetChild(7).gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
        }
    }


    private void NOTN()
    {
        Destroy(gameObject);
    }
}
