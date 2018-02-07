using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCamera : MonoBehaviour {
    public GameObject target;
    public GameObject player;
    public GameObject mainCamera;
    public GameObject UI;
    private bool once;
    public bool XboxCon;
	// Use this for initialization
	void Start () {
        once = false;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime *30f);
        transform.LookAt(target.transform);
        if (once == false)
        {
            Invoke("LetsStart", 6.0f);
        }

    }

    void LetsStart()
    {
        if (XboxCon == false)
        {
            player.GetComponent<Controller>().enabled = true;
        }
        else
        {
            player.GetComponent<ControllerXboxOne>().enabled = true;
        }
        GetComponent<Camera>().enabled = false;
        GetComponent<AudioListener>().enabled = false;
        mainCamera.SetActive(true);
        UI.SetActive(true);
        GetComponent<OpeningCamera>().enabled = false;
    }
}
