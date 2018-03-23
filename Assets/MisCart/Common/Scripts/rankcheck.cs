using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rankcheck : MonoBehaviour {
    private Text rank;
    private int ranknum;
	// Use this for initialization
	void Start () {
        rank = GameObject.FindWithTag("rank").GetComponent<Text>();
        ranknum = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            rank.text = ranknum.ToString();
            ranknum++;
            if (ranknum == 9)
            {
                ranknum = 1;
            }

        }
        else if(col.gameObject.tag=="CPU")
        {
            if (ranknum < 9)
            {
                ranknum++;
            }
            if (ranknum == 9)
            {
                ranknum = 1;
            }
        }
      
        Debug.Log(ranknum);
    }
}
