﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MisCart;

public class Controller : MonoBehaviour {
    new  Rigidbody rigidbody  ;
    AudioSource audio1;
    AudioSource audio2;
    float handle=80f;
    public float speed;
    public float limit=85f;
    private float limitset = 0;
    float limitrotate=5f;

    bool sound1=false;
    bool sound2 = false;
    bool isCounting = true;
    private float gravity=9.81f;
    float lPower ;
    float timer = 0f;
    int t,s,e;
    int i;

    Vector3 normalVector = Vector3.up;



    private void OnCollisionEnter(Collision col)
    {
        // 衝突した面の、接触した点における法線を取得
        if (col.collider.tag == "ground")
        {
            normalVector = col.contacts[0].normal;
        }
    }

    // Use this for initialization
    void Start () {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audio1 = audioSources[0];
        audio2 = audioSources[1];
        limitset = limit;

        rigidbody = this.GetComponent<Rigidbody>();
        t = 0;
        s = 0;
        e = 0;


    }

     void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {

            //audio1.Stop();
            SoundController.StopSE(Model.SE.SE_car_drive);
            sound1 = false;

        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            audio2.Stop();
            sound2 = false;
            e = t;
            if (e - s >= 100)
            {
                rigidbody.AddForce(transform.forward * speed / 2, ForceMode.Impulse);
            }
            limit = 85f;
            handle = 80f;
            s = 0; e = 0;
        }



        if (Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            //audio1.Stop();
            SoundController.StopSE(Model.SE.SE_car_drive);
            sound1 = false;
        }
        if (Input.GetKeyUp(KeyCode.Joystick1Button5))
        {
            audio2.Stop();
            sound2 = false;

            e = t;
            if (e - s >= 100)
            {
                rigidbody.AddForce(transform.forward * speed / 2, ForceMode.Impulse);
            }
            limit = 60f;
            handle = 40f;
            s = 0; e = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate () {

        //シーン遷移開始直後はIscountingが上手く取れないようなので0.5秒止めておく
        while(timer < 0.5f)
        {
            timer += Time.deltaTime;
            return;
        }

        //カウントダウンをしているときは動かないようにする
        if (isCounting)
        {
            isCounting = GameUI.GameUIManager.IsCounting();
            return;
        }



            if (Input.GetKey(KeyCode.Z))
            {
                //if (checkground())
                //{
                    if (rigidbody.velocity.magnitude <= limit)
                    {
                       if (sound1 == false)
                       {
                           //audio1.PlayOneShot(audio1.clip);
                            SoundController.PlaySE(Model.SE.SE_car_drive);
                            sound1 = true;
                       }

                      rigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);
                    }
                //}
            }
            if (Input.GetKeyUp(KeyCode.Z))
            {
                audio1.Stop();
                sound1 = false;

            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                s = t;

            }
        if (Input.GetKey(KeyCode.C))
        {
            if (sound2 == false)
            {
                audio2.PlayOneShot(audio2.clip);
                sound2 = true;
            }
            if (rigidbody.velocity.magnitude <= limit)
            {
                rigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);
            }
                //limit = 30f;
                handle = 130f;
            }
            if (Input.GetKeyUp(KeyCode.C))
            {
                audio2.Stop();
            sound2 = false;
                e = t;
                if (e - s >= 100)
                {
                    rigidbody.AddForce(transform.forward * speed / 2, ForceMode.Impulse);
                }
                limit = 85f;
                handle = 80f;
                s = 0; e = 0;
            }

        if (Input.GetKey(KeyCode.X))
        {
            rigidbody.AddForce(-transform.forward * speed,ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(transform.up*transform.GetComponent<Rigidbody>().mass, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 dir = new Vector3(0, -25f, 0);
            rigidbody.AddForce(dir, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0,-handle,0)*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, handle, 0) * Time.deltaTime);
        }

        //ここからコントローラ用//


        float joyH = Input.GetAxis("Horizontal");

        transform.Rotate(new Vector3(0, joyH*handle, 0) * Time.deltaTime);
        transform.Rotate(new Vector3(0, -6.5f, 0) * Time.deltaTime);    //コントローラ接続時のみ有効化
        if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            if (sound1 == false)
                {
                    audio1.PlayOneShot(audio1.clip);
                    sound1 = true;
                }


            if (rigidbody.velocity.magnitude <= limit)
            {
                

                rigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);
            }
        }
        if (Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            audio1.Stop();
            sound1 = false;
        }
            if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            s = t;
        }
        if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            if (sound2 == false)
            {
                audio2.PlayOneShot(audio2.clip);
                sound2 = true;
            }
            if (rigidbody.velocity.magnitude <= limit)
            {
                rigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);
            }
            //limit = 30f;
            handle = 80f;
        }
        if (Input.GetKeyUp(KeyCode.Joystick1Button5))
        {
            audio2.Stop();
            sound2 = false;

            e = t;
            if (e - s >= 100)
            {
                rigidbody.AddForce(transform.forward * speed / 2, ForceMode.Impulse);
            }
            limit = 60f;
            handle = 40f;
            s = 0; e = 0;
        }
        if (Input.GetKey(KeyCode.Joystick1Button1))
        {
            if (rigidbody.velocity.magnitude <= limit)
            {
                rigidbody.AddForce(-transform.forward * speed, ForceMode.Acceleration);
            }
        }

        t++;





        //転倒防止処理
        float angleDir2 = transform.eulerAngles.y * (Mathf.PI / 180.0f);
        Vector3 dir2 = new Vector3(Mathf.Sin(angleDir2), 0.0f, Mathf.Cos(angleDir2));


        transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir2),0.15f);
        //転倒防止処理ここまで
       


        if (checkground()==false)
        {
            rigidbody.AddForce(-new Vector3(0,1,0) * gravity*3, ForceMode.Acceleration);
        }
    }




    bool checkground()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.transform.tag == "ground")
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        else
        {
            return false;
        }

    }


    public void LimitCut()
    {
        limit = limit / 2;
        Invoke("LimitReset", 5f);
    }

    void LimitReset()
    {
        limit = limitset;
    }
}



