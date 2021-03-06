﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace UnityStandardAssets.Utility
{
    public class rank : MonoBehaviour
    {
        private WaypointCircuit circuit2;
        GameObject[] tagobjs;
        GameObject rtag;
        private int pathpoint;
        int reach;
        int next;
        int ranknum;
        private int nowRank;
        float dis;
        private Text ranktext;
        private float cpudis;
        private Text rankafter;

        private Color first =new Color(255f/255f,215f/255f,0f/255f);
        private Color second = new Color(192f / 255f, 192f / 255f, 192f / 255f);
        private Color third = new Color(196f / 255f, 112f / 255f, 34f / 255f);
        private Color noRank = new Color(1, 1, 1);
        // Use this for initialization
        public int GetRank()
        {
            return nowRank;
        }
        public GameObject gettag()
        {
            return rtag;
        }

        public int GetPathPoint()
        {
            return pathpoint;
        }

        void Start()
        {
            tagobjs = GameObject.FindGameObjectsWithTag("CPU");
            ranktext = GameObject.FindWithTag("rank").GetComponent<Text>();
            circuit2 = GameObject.Find("TagPointForAI").GetComponent<WaypointCircuit>();
            rankafter= GameObject.Find("AfterRank").GetComponent<Text>();
            reach = 0;
            next = 1;
            ranknum = 1;
            pathpoint = 0;

            nowRank = 8;

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            dis=GetFractionOfPathCovered(transform.position,circuit2.Waypoints[reach].position,circuit2.Waypoints[next].position);
            
            if (dis > 1)
            {
                
                pathpoint++;
                reach++;
                next++;

                if (reach == circuit2.Waypoints.Length-1)
                {
                    next = 0;
                }
                if (reach == circuit2.Waypoints.Length)
                {
                    reach = 0;
                    next = 1;
                }
            }
            if (transform.tag == "Player")
            {
                foreach (GameObject obj in tagobjs)
                {
                    if (obj.GetComponent<rank>().GetPathPoint() < pathpoint)
                    {
                        ranknum--;
                        cpudis = Mathf.Clamp(GetFractionOfPathCovered(obj.transform.position, circuit2.Waypoints[reach].position, circuit2.Waypoints[next].position), 0, 5f);
                        if (cpudis < dis)
                        {
                            rtag = obj;
                        }
                    }                    
                    else if(obj.GetComponent < rank>().GetPathPoint() == pathpoint)
                    {
                        cpudis = Mathf.Clamp(GetFractionOfPathCovered(obj.transform.position, circuit2.Waypoints[reach].position, circuit2.Waypoints[next].position),0,5f);
                        if (cpudis < dis)
                        {
                            ranknum--;
                            rtag = obj;
                        }
                    }
                    else if(obj.GetComponent<rank>().GetPathPoint() > pathpoint)
                    {
                        cpudis = Mathf.Clamp(GetFractionOfPathCovered(obj.transform.position, circuit2.Waypoints[reach].position, circuit2.Waypoints[next].position), 0, 5f);
                        if (cpudis < dis)
                        {
                            rtag = obj;
                        }
                    }
                    
                }
                ranktext.text = ranknum.ToString();
                if ((ranknum <= 8) && (ranknum >= 4))
                {
                    rankafter.text = "th";
                    ranktext.color = noRank;
                    rankafter.color = noRank;
                }else if (ranknum == 3)
                {
                    rankafter.text = "rd";
                    ranktext.color = third;
                    rankafter.color = third;
                }
                else if (ranknum == 2)
                {
                    rankafter.text = "nd";
                    ranktext.color = second;
                    rankafter.color = second;
                }
                else if (ranknum == 1)
                {
                    rankafter.text = "st";
                    ranktext.color = first;
                    rankafter.color = first;
                }

                nowRank = ranknum;
                ranknum = 8;
            }

        }

        public float GetFractionOfPathCovered(Vector3 position, Vector3 lastNodeReached, Vector3 nextNode)
        {
            Vector3 displacementFromCurrentNode = position - lastNodeReached;
            Vector3 currentSegmentVector = nextNode - lastNodeReached;
            float fraction = Vector3.Dot(displacementFromCurrentNode, currentSegmentVector) /
                currentSegmentVector.sqrMagnitude;


            return fraction;

        }
    }
}
