using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPsystem : MonoBehaviour {
    private TutorialManager TS;
	// Use this for initialization
	void Start () {
        TS = GameObject.Find("TutorialSystem").GetComponent<TutorialManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            TS.StartNextPhase();
            Destroy(gameObject);
        }
    }
}
