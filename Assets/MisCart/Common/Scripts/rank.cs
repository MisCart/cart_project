using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Utility
{
    public class rank : MonoBehaviour
    {
        [SerializeField]
        private Transform[] circuit;
        GameObject[] tagobjs;
        int reach;
        int next;
        int ranknum;
        float dis;
        private Text ranktext;
        // Use this for initialization
        void Start()
        {
            tagobjs = GameObject.FindGameObjectsWithTag("CPU");
            ranktext = GameObject.FindWithTag("rank").GetComponent<Text>();
            reach = 0;
            next = 1;
            ranknum = 1;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            dis=GetFractionOfPathCovered(transform.position,circuit[reach].position,circuit[next].position);
            if (dis > 1)
            {
                reach++;
                next++;

                if (reach == 13)
                {
                    next = 0;
                }
                if (reach == 14)
                {
                    reach = 0;
                    next = 1;
                }
            }

            foreach(GameObject obj in tagobjs)
            {
                float cpudis= GetFractionOfPathCovered(obj.transform.position, circuit[reach].position, circuit[next].position);
                if ((cpudis > dis)||(cpudis>1))
                {
                    ranknum++;
                }
            }
            ranktext.text = ranknum.ToString();
            ranknum = 1;

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
