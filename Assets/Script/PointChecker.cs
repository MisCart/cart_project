using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointChecker : MonoBehaviour
{
    public GameObject Goal;
    private int laps;
    private int check;
    // Use this for initialization
    void Start()
    {
        laps = 0;
        check = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (check == laps)
            {
                Goal.SendMessage("Check");
                Debug.Log("check");
                Debug.Log(check);
                check++;
            }
        }

    }
    void changeLaps()
    {
        if (laps < check)
        {
            laps++;
        }
    }
}
