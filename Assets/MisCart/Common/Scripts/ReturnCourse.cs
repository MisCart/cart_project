using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class ReturnCourse : MonoBehaviour {
    private GameObject Player;
    private bool canReturn = false;
    [SerializeField] private Transform zeropos;
    [SerializeField] private Transform onepos;
    private SetTimer setTimer;
    [SerializeField] private bool isSibazono=false; 
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        setTimer = GetComponent<SetTimer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (canReturn)
        {
            if((Input.GetKeyDown(KeyCode.Joystick1Button1)) || (Input.GetKeyDown(KeyCode.Joystick1Button13)) || (Input.GetKeyDown(KeyCode.Z)))
            {
                if (setTimer.GetNowPos() == 0)
                {
                    Player.transform.position = zeropos.position;
                    Player.GetComponent<WaypointProgressTracker>().SetProgressDistance(0);
                }else if (setTimer.GetNowPos() == 1)
                {
                    Player.transform.position = onepos.position;
                    Player.GetComponent<WaypointProgressTracker>().SetProgressDistance(1);
                }
                canReturn = false;
            }

        }
        if (!isSibazono)
        {
            if (Player.transform.position.y <= 440)
            {
                if (!canReturn)
                {
                    canReturn = true;
                }
            }
        }
        else
        {
            if (Player.transform.position.y <= -20)
            {
                if (!canReturn)
                {
                    canReturn = true;
                }
            }
        }
	}

    public void SetP(GameObject player)
    {
        Player = player;
    }

}
