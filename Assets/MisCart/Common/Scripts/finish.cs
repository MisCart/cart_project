using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finish : MonoBehaviour {
    public GameObject racetext;
    public GameObject finishtext;
    public GameObject ranktext;
    public GameObject player;
    public GameObject minimap;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void finishrace(int rank)
    {
        racetext.SetActive(false);
        finishtext.SetActive(true);
        minimap.SetActive(false);
        ranktext.GetComponent<Text>().text = rank.ToString();
        player.GetComponent<Controller>().enabled = false;
        player.GetComponent<WaypointAgent>().enabled = true;
    }
}
