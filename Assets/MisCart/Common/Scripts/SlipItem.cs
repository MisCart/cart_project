using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipItem : MonoBehaviour {
    private AudioSource down;
    private AudioSource set;
	// Use this for initialization
	void Start () {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        down = audioSources[0];
        set = audioSources[1];
        set.PlayOneShot(set.clip);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Controller>().LimitCut();
            down.PlayOneShot(down.clip);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Invoke("Dess",2);
        }else if (other.gameObject.tag == "CPU")
        {
            other.gameObject.GetComponent<WaypointAgent>().LimitCut();
            down.PlayOneShot(down.clip);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Invoke("Dess", 2);
        }
    }
    void Dess()
    {
        Destroy(gameObject);
    }
}
