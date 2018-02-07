using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTimer : MonoBehaviour {
    private int minite;
    private float second;
    private int oldMinite;
    private float oldSecond;
    private int lapMinite;
    private float lapSecond;
    private bool timarFlag = false;
    private int laps;
    private int check;
    public GameObject timer;
    public GameObject lapbox;
    public GameObject checker;
    public GameObject lap1;
    public GameObject lap2;
    public GameObject lap3;
    // Use this for initialization
    void Start () {
        minite = 0;
        second = 0;
        oldMinite = 0;
        oldSecond = 0;
        lapMinite = 0;
        lapSecond = 0;
        laps = 0;
        check = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale > 0)
        {
            if (timarFlag == true)
            {
                second += Time.deltaTime;
                if (second >= 60.0f)
                {
                    minite++;
                    second = second - 60;
                }
                timer.GetComponent<Text>().text = minite.ToString("00") + ":" + second.ToString("00");
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            check++;
            Debug.Log(check);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (laps == 3 && check == 3)
            {
                lapMinite = minite - oldMinite;
                if (second - oldSecond < 0)
                {
                    lapSecond = 60 + second - oldSecond;
                    lapMinite--;
                }
                else
                {
                    lapSecond = second - oldSecond;
                }
                lap3.GetComponent<Text>().text = lapMinite.ToString("00") + ":" + lapSecond.ToString("00");
                Debug.Log("Finish");
            }
            if (laps == 2 && check == 2)
            {
                lapMinite = minite - oldMinite;
                if (second - oldSecond < 0)
                {
                    lapSecond = 60 + second - oldSecond;
                    lapMinite--;
                }
                else
                {
                    lapSecond = second - oldSecond;
                }
                lap2.GetComponent<Text>().text = lapMinite.ToString("00") + ":" + lapSecond.ToString("00");
                oldMinite = minite;
                oldSecond = second;
                laps++;
            }
            if (check == 1 && laps == 1)
            {
                lap1.GetComponent<Text>().text = minite.ToString("00") + ":" + second.ToString("00");
                oldMinite = minite;
                oldSecond = second;
                laps++;
            }
            if (check == 0 && laps == 0)
            {
                timarFlag = true;
                laps++;
            }
            lapbox.GetComponent<Text>().text = laps.ToString("0");
            Debug.Log("laps");
            Debug.Log(laps);
            checker.SendMessage("changeLaps");
        } 
    }
    void Check()
    {
        if (check < laps)
        {
            check++;
        }
    }
}
