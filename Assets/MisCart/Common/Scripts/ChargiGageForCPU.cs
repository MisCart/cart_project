using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MisCart;

public class ChargiGageForCPU : MonoBehaviour {
    public float charging=100f;
    private float power = 100f;
    bool inval = false;
    float timer = 0f;

    private bool DoneStartDash = false;
    private float StartdashTime = 0;

    private bool canGo;



    // Use this for initialization
    void Start()
    {
        canGo = true;
    }
    void Update()
    {

        //シーン遷移開始直後はIscountingが上手く取れないようなので0.5秒止めておく
        while (timer < 0.5f)
        {
            timer += Time.deltaTime;
            return;
        }

        //カウントダウンをしているときは動かないようにする
        if (GameUI.GameUIManager.IsCounting())
        {
            return;
        }

        if (!DoneStartDash)
        {
            if (Random.Range(0, 2) == 0)
            {

                GetComponent<Rigidbody>().AddForce(transform.forward * power * 1.5f, ForceMode.VelocityChange);
                SoundController.PlaySE(Model.SE.BoostCPU);

            }

            charging -= 30;
            DoneStartDash = true;
   

        }

        if (canGo)
        {
            if (inval == false)
            {
                if (charging > 10)
                {
                    GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);
                    SoundController.PlaySE(Model.SE.BoostCPU);
                    charging -= 10;
                }
                
                
                inval = true;
            }
            Invoke("Stay", 3.0f);
            canGo = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       
        //シーン遷移開始直後はIscountingが上手く取れないようなので0.5秒止めておく
        while (timer < 0.5f)
        {
            timer += Time.deltaTime;
            return;
        }

        if (GameUI.GameUIManager.IsCounting())
        {
            return;
        }

        if (charging > 0)
        {
            charging -= 0.05f;
        }
        if (charging > 100)
        {
            charging = 100;
        }
        if (charging < 0)
        {
            charging = 0;
        }
        
    }
   
    void Stay()
    {
        inval = false;
        var i = Random.Range(3, 10);
        Invoke("Interval", i);
    }

    private void Interval()
    {
        canGo = true;
    }
}
