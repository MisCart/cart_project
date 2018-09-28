using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItem : MonoBehaviour {


    [SerializeField] private int Cart = 0;//P=1.M=2,C=3
	// Use this for initialization
	void Start () {
		
	}
    public int GetWhichCart()
    {
        return Cart;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UseSpecialItem()
    {
        if (Cart==1)
        {
            GetComponent<HackingMedia>().HackStart();
        }else if (Cart==2)
        {
            GetComponent<DeathMetal>().DeathMetalStart();
        }
        else if (Cart==3)
        {
            GetComponent<PaintDan>().PaintStart();
        }
    }
}
