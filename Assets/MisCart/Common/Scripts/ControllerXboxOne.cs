using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerXboxOne : MonoBehaviour {
    new Rigidbody rigidbody;
    float handle = 40f;
    public float speed;
    float limit = 60f;
    float lPower;
    int t, s, e;
    // Use this for initialization
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        t = 0;
        s = 0;
        e = 0;


    }

    // Update is called once per frame
    void Update()
    {

        lPower = speed;
        if ((rigidbody.velocity.x) >= limit)
        {
            rigidbody.AddForce(new Vector3(-lPower, 0, 0));
        }
        if ((rigidbody.velocity.x) <= -limit)
        {
            rigidbody.AddForce(new Vector3(lPower, 0, 0));
        }
        if ((rigidbody.velocity.y) >= limit)
        {
            rigidbody.AddForce(new Vector3(0, -lPower, 0));
        }
        if ((rigidbody.velocity.y) <= -limit)
        {
            rigidbody.AddForce(new Vector3(0, lPower, 0));
        }
        if ((rigidbody.velocity.z) >= limit)
        {
            rigidbody.AddForce(new Vector3(0, 0, -lPower));
        }
        if ((rigidbody.velocity.z) <= -limit)
        {
            rigidbody.AddForce(new Vector3(0, 0, lPower));
        }


        if (Input.GetKey(KeyCode.Z))
        {
            float angleDir = transform.eulerAngles.y * (Mathf.PI / 180.0f);
            Vector3 dir = new Vector3(Mathf.Sin(angleDir), 0.0f, Mathf.Cos(angleDir));
            rigidbody.AddForce(dir * speed, ForceMode.Acceleration);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            s = t;
        }
        if (Input.GetKey(KeyCode.C))
        {
            limit = 30f;
            handle = 80f;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            e = t;
            if (e - s >= 100)
            {
                float angleDir2 = transform.eulerAngles.y * (Mathf.PI / 180.0f);
                Vector3 dir2 = new Vector3(Mathf.Sin(angleDir2), 0.0f, Mathf.Cos(angleDir2));
                rigidbody.AddForce(dir2 * speed / 2, ForceMode.Impulse);
            }
            limit = 60f;
            handle = 40f;
            s = 0; e = 0;
        }
        if (Input.GetKey(KeyCode.X))
        {
            float angleDir = transform.eulerAngles.y * (Mathf.PI / 180.0f);
            Vector3 dir = new Vector3(Mathf.Sin(angleDir), 0.0f, Mathf.Cos(angleDir));
            rigidbody.AddForce(-dir * speed / 2);

        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 dir = new Vector3(0, 0.5f, 0);
            rigidbody.AddForce(dir, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 dir = new Vector3(0, -25f, 0);
            rigidbody.AddForce(dir, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -handle, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, handle, 0) * Time.deltaTime);
        }



        //ここからコントローラ用//


        float joyH = Input.GetAxis("Horizontal");

        transform.Rotate(new Vector3(0, joyH * handle, 0) * Time.deltaTime);
        transform.Rotate(new Vector3(0, -6.5f, 0) * Time.deltaTime);    //コントローラ接続時のみ有効化
        if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            float angleDir = transform.eulerAngles.y * (Mathf.PI / 180.0f);
            Vector3 dir = new Vector3(Mathf.Sin(angleDir), 0.0f, Mathf.Cos(angleDir));
            rigidbody.AddForce(dir * speed, ForceMode.Acceleration);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            s = t;
        }
        if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            limit = 30f;
            handle = 80f;
        }
        if (Input.GetKeyUp(KeyCode.Joystick1Button5))
        {
            e = t;
            if (e - s >= 100)
            {
                float angleDir2 = transform.eulerAngles.y * (Mathf.PI / 180.0f);
                Vector3 dir2 = new Vector3(Mathf.Sin(angleDir2), 0.0f, Mathf.Cos(angleDir2));
                rigidbody.AddForce(dir2 * speed / 2, ForceMode.Impulse);
            }
            limit = 60f;
            handle = 40f;
            s = 0; e = 0;
        }
        if (Input.GetKey(KeyCode.Joystick1Button2))
        {
            float angleDir = transform.eulerAngles.y * (Mathf.PI / 180.0f);
            Vector3 dir = new Vector3(Mathf.Sin(angleDir), 0.0f, Mathf.Cos(angleDir));
            rigidbody.AddForce(-dir * speed / 2);

        }

        t++;
    }
}
