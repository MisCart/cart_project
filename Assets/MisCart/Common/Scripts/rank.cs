using System.Collections;
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
