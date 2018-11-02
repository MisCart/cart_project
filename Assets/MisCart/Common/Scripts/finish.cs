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
    private GameObject PgameObject;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        GameData.isFinish=false;
        PgameObject = GameObject.Find("UI/Canvas/enogu");
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
        PgameObject.SetActive(false);
        mainCamera.GetComponent<AutoCam>().Goal();
        player.GetComponent<Controller>().enabled = false;
        player.GetComponent<WaypointAgent>().enabled = true;
        SoundController.StopAll(0.5f);

        GameData.isFinish = true;
        DOTween.To(
        () => vol,          // 何を対象にするのか
        vol => mainCamera.GetComponent<AudioSource>().volume = vol,   // 値の更新
        0,                  // 最終的な値
        0.1f                  // アニメーション時間
        ).OnComplete(()=>SetEndFlag(true));
        Invoke("kesuyatu",3.5f);
    }

    private void kesuyatu()
    {
        //サウンドマネージャーで鳴らしている音を消す
        end = true;

        finishtext.SetActive(false);
        GameUIManager.StartAnimation();

    }

    void SetEndFlag(bool value){
        SoundController.PlaySE(Model.SE.Fanfare);
        //end = value;
    }
}
