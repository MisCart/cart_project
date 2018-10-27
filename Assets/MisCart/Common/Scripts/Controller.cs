using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MisCart;

public class Controller : MonoBehaviour {
    new  Rigidbody rigidbody  ;

    [SerializeField]private float handle=80f;
    public float speed;
    public float limit=85f;
    private float limitset = 0;
    private float speedset = 0;
    private float handleset = 0;
    float limitrotate=5f;
    bool sound1=false;
    bool sound2 = false;
    private float gravity=9.81f;
    float lPower ;
    float timer = 0f;
    int t,s,e;
    int i;
    private bool con = false;

    private Color playerColor;

    [SerializeField] private GameObject sparks;

    // Use this for initialization
    void Start () {
        limitset = limit;
        handleset = handle;

        rigidbody = this.GetComponent<Rigidbody>();
        t = 0;
        s = 0;
        e = 0;
        playerColor = GetComponent<Renderer>().material.GetColor("_Color");
        var controllerNames = Input.GetJoystickNames();
        if (controllerNames.Length== 0)
        {
            Debug.Log("Controller not connect");
            con = false;
        }
        else
        {
            Debug.Log("Controller connect");
            con = true;
        }
       
    }

     void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            SoundController.StopSE(Model.SE.EngineSound);
            sound1 = false;

        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            SoundController.StopSE(Model.SE.braking);
            sound2 = false;
            e = t;
            if (e - s >= 100)
            {
                rigidbody.AddForce(transform.forward * speed / 2, ForceMode.Impulse);
            }
            limit = limitset;
            handle = handleset;
            s = 0; e = 0;
        }



        if ((Input.GetKeyUp(KeyCode.Joystick1Button1))||(Input.GetKeyUp(KeyCode.Joystick1Button13)))
        {
            SoundController.StopSE(Model.SE.EngineSound);
            sound1 = false;
        }
        if ((Input.GetKeyUp(KeyCode.Joystick1Button5))||(Input.GetKeyUp(KeyCode.Joystick1Button11)))
        {
            SoundController.StopSE(Model.SE.braking);
            sound2 = false;

            e = t;
            if (e - s >= 100)
            {
                rigidbody.AddForce(transform.forward * speed / 2, ForceMode.Impulse);
            }
            limit = limitset;
            handle = handleset;
            s = 0; e = 0;
        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            if (sparks.activeSelf==false)
            {
                sparks.SetActive(true);
            }
        }

        if ((Input.GetKeyUp(KeyCode.LeftArrow))||(Input.GetKeyUp(KeyCode.RightArrow)))
        {
            sparks.SetActive(false);
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
        if (GameUI.GameUIManager.IsCounting()){
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
                            SoundController.PlaySE(Model.SE.EngineSound);
                            sound1 = true;
                       }

                      //rigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);

                    float angleDir = transform.eulerAngles.y * (Mathf.PI / 180.0f);
                    Vector3 dir = new Vector3(Mathf.Sin(angleDir), 0.0f, Mathf.Cos(angleDir));

                    rigidbody.AddForce(dir * speed, ForceMode.Acceleration);
                    }
                //}
            }

            if (Input.GetKeyUp(KeyCode.Z))
            {
                SoundController.StopSE(Model.SE.EngineSound);
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
                SoundController.PlaySE(Model.SE.braking);
                sound2 = true;
            }
            if (rigidbody.velocity.magnitude <= limit)
            {
               // rigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);
            }
            //limit = 30f;
            handle = handleset * 2; ;
        }

            if (Input.GetKeyUp(KeyCode.C))
            {
                SoundController.StopSE(Model.SE.braking);
                sound2 = false;
                e = t;
                if (e - s >= 100)
                {
                    rigidbody.AddForce(transform.forward * speed / 2, ForceMode.Impulse);
                }
                limit = limitset;
                handle = handleset;
                s = 0; e = 0;
            }

        if (Input.GetKey(KeyCode.X))
        {
            rigidbody.AddForce(-transform.forward * speed,ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(transform.up*transform.GetComponent<Rigidbody>().mass*3, ForceMode.Impulse);
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
        if ((joyH >= 0.3f)||(joyH<=-0.3f)){if (sparks.activeSelf == false){sparks.SetActive(true);}}
        else{sparks.SetActive(false);}

        if (con)
        {
            transform.Rotate(new Vector3(0, -6.5f, 0) * Time.deltaTime);    //コントローラ接続時のみ有効化
        }
        if ((Input.GetKey(KeyCode.Joystick1Button1))||(Input.GetKey(KeyCode.Joystick1Button13)))
        {
            if (sound1 == false)
                {
                    SoundController.PlaySE(Model.SE.EngineSound);
                    sound1 = true;
                }


            if (rigidbody.velocity.magnitude <= limit)
            {

                rigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);
            }
        }
        if ((Input.GetKeyUp(KeyCode.Joystick1Button1))||(Input.GetKey(KeyCode.Joystick1Button13)))
        {
            SoundController.StopSE(Model.SE.EngineSound);
            sound1 = false;
        }
            if ((Input.GetKeyDown(KeyCode.Joystick1Button5))||(Input.GetKey(KeyCode.Joystick1Button11)))
        {
            s = t;
        }
        if ((Input.GetKey(KeyCode.Joystick1Button5))||(Input.GetKey(KeyCode.Joystick1Button11)))
        {
            if (sound2 == false)
            {
                SoundController.PlaySE(Model.SE.braking);
                sound2 = true;
            }
            if (rigidbody.velocity.magnitude <= limit)
            {
                //rigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);
            }
            //limit = 30f;
            handle = handleset * 2;
        }
        if ((Input.GetKeyUp(KeyCode.Joystick1Button5))||(Input.GetKey(KeyCode.Joystick1Button11)))
        {
            SoundController.StopSE(Model.SE.braking);
            sound2 = false;

            e = t;
            if (e - s >= 100)
            {
                rigidbody.AddForce(transform.forward * speed / 2, ForceMode.Impulse);
            }
            limit = limitset;
            handle = handleset;
            s = 0; e = 0;
        }
        if ((Input.GetKey(KeyCode.Joystick1Button0))||(Input.GetKey(KeyCode.Joystick1Button14)))
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

        if (((transform.eulerAngles.x >= 50f) && (transform.eulerAngles.x <= 310f))||((transform.eulerAngles.z >= 50f) && (transform.eulerAngles.z <= 310f)))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir2), 0.5f);
        }
        //transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir2),0.5f);//0.15f//X軸について
        //転倒防止処理ここまで



        if (checkground()==false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir2), 0.015f);
            rigidbody.AddForce(new Vector3(0,-1,0) * gravity*3, ForceMode.Acceleration);
            transform.position += new Vector3(0,-0.1f,0);
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

    public void LimitCutShort()
    {
        limit = limit / 2;
        Invoke("LimitReset", 1.5f);
    }

    void LimitReset()
    {
        limit = limitset;
        GetComponent<Renderer>().material.SetColor("_Color",playerColor);
    }
}



