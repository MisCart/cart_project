using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MisCart;

public class ItemSellect : MonoBehaviour {
    int itemnum = 0;
    private Animator _anim;
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        _anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SellectStart()
    {
        _anim.Play("ItemSelect");
        SoundController.PlaySE(Model.SE.item);
    }

    public void Kettei()
    {
        player.GetComponent<itemsystem>().sellectitem();
        SoundController.StopSE(Model.SE.item);
        SoundController.PlaySE(Model.SE.itemselect);
    }
}
