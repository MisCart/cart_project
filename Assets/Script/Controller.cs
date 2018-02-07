using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    new  Rigidbody rigidbody  ;

    float handle=40f;
    public float speed;
    float limit=60f;
    float limitrotate=5f;

    private float gravity=25f;
    float lPower ;
    int t,s,e;
    int i;

    Vector3 normalVector = Vector3.zero;


    private void OnCollisionStay(Collision collision)
    {
        // 衝突した面の、接触した点における法線を取得
        normalVector = collision.contacts[0].normal;
    }

    // Use this for initialization
    void Start () {
        
        rigidbody = this.GetComponent<Rigidbody>();
        t = 0;
        s = 0;
        e = 0;


    }
	
	// Update is called once per frame
	void FixedUpdate () {
        

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
            rigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            s = t;
        }
        if (Input.GetKey(KeyCode.C))
        {
            rigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);
            limit = 30f;
            handle = 80f;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            e = t;
            if (e - s >= 100)
            {
                rigidbody.AddForce(transform.forward * speed / 2, ForceMode.Impulse);
            }
            limit = 60f;
            handle = 40f;
            s = 0; e = 0;
        }
        if (Input.GetKey(KeyCode.X))
        {         
            rigidbody.AddForce(-transform.forward * speed/2);  
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
        //transform.Rotate(new Vector3(0, -6.5f, 0) * Time.deltaTime);    //コントローラ接続時のみ有効化
        if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            rigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);
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
                rigidbody.AddForce(transform.forward * speed / 2, ForceMode.Impulse);
            }
            limit = 60f;
            handle = 40f;
            s = 0; e = 0;
        }
        if (Input.GetKey(KeyCode.Joystick1Button2))
        {
            rigidbody.AddForce(-transform.forward * speed /2);

        }
       
        t++;


       

        Vector3 onPlane = Vector3.ProjectOnPlane(transform.forward, normalVector);

        transform.localRotation = Quaternion.LookRotation(onPlane,normalVector );

     

        rigidbody.AddForce(-normalVector*gravity, ForceMode.Acceleration);
        if (normalVector == Vector3.zero)
        {
            rigidbody.AddForce(-transform.up*gravity, ForceMode.Acceleration);
        }
    }

    
}

