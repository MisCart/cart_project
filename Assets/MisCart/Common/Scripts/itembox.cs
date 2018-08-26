using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itembox : MonoBehaviour {
    bool playback;
    int playbacktime;
    AudioSource itemget;
    // Use this for initialization
    void Start () {
        playback = false;
        playbacktime = 0;
        itemget= GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.Rotate(new Vector3(0, 0, 1));
        if (playback == true)
        {
            playbacktime++;
        }
        if (playbacktime > 240)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;
            playback = false;
            playbacktime = 0;
        }
	}


    void itemcollision()
    {
        itemget.PlayOneShot(itemget.clip);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        playback = true;
    }
}
