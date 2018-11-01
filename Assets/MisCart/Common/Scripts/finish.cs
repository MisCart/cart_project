using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameUI;
using MisCart;
using DG.Tweening;

public class finish : MonoBehaviour {
    public GameObject racetext;
    public GameObject finishtext;
    public GameObject ranktext;
    private GameObject player;
    private GameObject mainCamera;
    public GameObject minimap;
    private float vol = 1f;
    private bool end = false;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

	// Update is called once per frame
	void Update () {
        if (end)
        {
            SoundController.StopAll();
        }
	}

    public void finishrace(int rank)
    {
        racetext.SetActive(false);
        finishtext.SetActive(true);
        minimap.SetActive(false);
        mainCamera.GetComponent<AutoCam>().Goal();
        //ranktext.GetComponent<Text>().text = rank.ToString();
        player.GetComponent<Controller>().enabled = false;
        player.GetComponent<WaypointAgent>().enabled = true;
        SoundController.StopAll(1f);
        SoundController.PlaySE(Model.SE.Fanfare);
        Invoke("kesuyatu",3f);
    }

    private void kesuyatu()
    {
        finishtext.SetActive(false);
        GameUIManager.StartAnimation();
        SoundController.StopAll();
        DOTween.To(
        () => vol,          // 何を対象にするのか
        vol => mainCamera.GetComponent<AudioSource>().volume=vol,   // 値の更新
        0,                  // 最終的な値
        2.0f                  // アニメーション時間
        ).OnComplete(() => SetEndFlag(true));
    }

    void SetEndFlag(bool value){
        end = value;
    }
}
