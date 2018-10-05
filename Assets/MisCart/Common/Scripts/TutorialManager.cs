﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private GameObject player;
    [SerializeField] private Massage UI;
    private Controller _controller;
    private bool activeCon=false;
    private int mPhase = 0;
	// Use this for initialization
    public void StartNextPhase()
    {
        SwitchActive(false);
        UI.ChangeGotoStep(true);
        mPhase++;
    }
	void Start () {
        _controller = player.GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
        if (activeCon)
        {
            _controller.enabled = true;
        }
        else
        {
            _controller.enabled = false;
        }
	}

    public void SwitchActive(bool a)
    {
        activeCon = a;
    }
}
