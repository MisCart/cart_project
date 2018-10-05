using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCarts : MonoBehaviour {

    private bool Inarea;
    public bool GetInSearch()
    {
        return Inarea;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.transform.tag=="enemy")&&(other.gameObject.transform.tag == "Player"))
        {
            Inarea = true;
        }
        else
        {
            Inarea = false;
        } 
    }
}
