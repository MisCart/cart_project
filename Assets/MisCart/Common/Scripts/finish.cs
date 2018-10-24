using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameUI;
using MisCart;

public class finish : MonoBehaviour {
    public GameObject racetext;
    public GameObject finishtext;
    public GameObject ranktext;
    private GameObject player;
    private GameObject mainCamera;
    public GameObject minimap;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void finishrace(int rank)
    {
        racetext.SetActive(false);
        finishtext.SetActive(true);
        minimap.SetActive(false);
        mainCamera.GetComponent<AutoCam>().Goal();
        //ranktext.GetComponent<Text>().text = rank.ToString();
        player.GetComponent<Controller>().enabled = false;
        player.GetComponent<WaypointAgent>().enabled = true;
        Invoke("kesuyatu",1f);

    }

    private void kesuyatu()
    {
        finishtext.SetActive(false);
        GameUIManager.StartAnimation();
        mainCamera.GetComponent<AudioSource>().volume = 0f;
    }
}
