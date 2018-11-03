using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;
using MisCart;

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
    private int rank;
    public GameObject timer;
    private Text timertext;
    public GameObject lapbox;
    public GameObject checker;
    public GameObject lap1;
    public GameObject lap2;
    public GameObject lap3;
    public GameObject finishobject;
    private GameObject player;
    private float time;
    // Use this for initialization
    void Start () {
        rank = 1;
        minite = 0;
        second = 0;
        oldMinite = 0;
        oldSecond = 0;
        lapMinite = 0;
        lapSecond = 0;
        laps = 0;
        check = 0;
        time = 0;
        timertext = timer.GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale > 0)
        {
            if (timarFlag == true)
            {
                time += Time.deltaTime;
                int minute = (int)time / 60;
                int second = (int)time % 60;
                int msecond = (int)(time * 1000 % 1000);
                string minText, secText, msecText;
                if (minute < 10)
                {
                    minText = "0" + minute.ToString();
                }
                else
                { 
                    minText = minute.ToString();
                }
                if (second < 10)
                {
                    secText = "0" + second.ToString();
                }
                else
                {
                    secText = second.ToString();
                }

                if (msecond < 10)
                {
                    msecText = "00" + msecond.ToString();
                }
                else if (msecond < 100)
                {
                    msecText = "0" + msecond.ToString();
                }
                else 
                {
                    msecText = msecond.ToString();
                }
               

               
                timertext.text = minText + ":" + secText + ":" + msecText; 
            }
        }

        

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (laps == 3 && check == 3)
            {
                //finishobject.GetComponent<finish>().finishrace(rank);
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

                GameData.FinishRank = player.GetComponent<rank>().GetRank();
                GameData.FinishTime = time;

                finishobject.GetComponent<finish>().finishrace(player.GetComponent<rank>().GetRank());

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
                //finishobject.GetComponent<finish>().finishrace(rank);
                SoundController.PlaySE(Model.SE.lap);
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
            checker.SendMessage("changeLaps");
        }else if (col.gameObject.tag=="CPU")
        {
            
            if (check == 2 && laps == 2)
            {
                rank++;
                Debug.Log(rank);
            }
        }
    }
    void Check()
    {
        if (check < laps)
        {
            check++;
        }
    }

    public int GetNowPos()
    {
        Debug.Log("check="+check+", laps="+laps);
        if (check != laps)
        {
            return 0;//0はゴール前
        }
        else
        {
            return 1;
        }
    }
}
