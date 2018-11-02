using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MisCart;

public class itembox : MonoBehaviour {
    bool playback;
    int playbacktime;
    // Use this for initialization
    void Start () {
        playback = false;
        playbacktime = 0;
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
        if (!GameData.isFinish)
        {
            SoundController.PlaySE(Model.SE.powerup2);
        }
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        playback = true;
    }
}
