using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
[RequireComponent(typeof(WaypointProgressTracker))]
public class WaypointAgent : MonoBehaviour {
    private WaypointProgressTracker tracker = null;

    [SerializeField, Range(0, 800)]
    protected float speed = 1;
    [SerializeField]
    private float m_MaximumSteerAngle;
    [SerializeField]
    private float SteerLevel;
    [SerializeField]
    private float m_CautiousAngularVelocityFactor = 30f;
    [SerializeField]
    [Range(0, 180)]
    private float m_CautiousMaxAngle = 50f;
    [SerializeField]
    [Range(0, 1)]
    private float m_CautiousSpeedFactor = 0.05f;
    [SerializeField]
    private float m_AccelSensitivity = 0.04f;
    [SerializeField]
    private float m_BrakeSensitivity = 1f;
    private float gravity = 9.81f;

    new private Rigidbody rigidbody;
    [SerializeField, Range(0, 500)]

    float limit = 140f;
    float limitset = 0;
    float lPower = 60f;
    float timer = 0f;
    Vector3 correction = Vector3.zero;
    private Color cartcolor;
    // Use this for initialization
    void Start () {
        limitset = limit;
        tracker = GetComponent<WaypointProgressTracker>();
        rigidbody = GetComponent<Rigidbody>();
        correction = new Vector3(Random.Range(-5.0f,5.0f),0,Random.Range(-5.0f,5.0f));
        cartcolor=gameObject.transform.GetChild(7).gameObject.GetComponent<Renderer>().material.GetColor("_Color");

    }

    // Update is called once per frame
    void FixedUpdate() {

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

        Vector3 fwd = transform.forward;
        float desiredSpeed = limit;
        // check out the angle of our target compared to the current direction of the car
        float approachingCornerAngle = Vector3.Angle(tracker.target.forward, fwd);

        // also consider the current amount we're turning, multiplied up and then compared in the same way as an upcoming corner angle
        float spinningAngle = rigidbody.angularVelocity.magnitude * m_CautiousAngularVelocityFactor;

        // if it's different to our current angle, we need to be cautious (i.e. slow down) a certain amount
        float cautiousnessRequired = Mathf.InverseLerp(0, m_CautiousMaxAngle,
                                                       Mathf.Max(spinningAngle,
                                                                 approachingCornerAngle));
        desiredSpeed = Mathf.Lerp(limit, limit * m_CautiousSpeedFactor,
                                  cautiousnessRequired);

        if (desiredSpeed < rigidbody.velocity.magnitude)
        {
            float brake = Mathf.Clamp((desiredSpeed - rigidbody.velocity.magnitude) * m_BrakeSensitivity, -1, 1) * speed;
            rigidbody.AddForce(transform.forward * brake * 15, ForceMode.Force);
        }
        if (rigidbody.velocity.magnitude <= limit)
        {
            rigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);


        }

        Vector3 localTarget = tracker.target.position - transform.position+correction;

        float targetAngle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        //float steer = Mathf.Clamp(targetAngle * 0.01f, -1, 1)* Mathf.Sign(rigidbody.velocity.magnitude * 2.23693629f);

        //float m_SteerAngle = steer * SteerLevel;




        Vector3 dir2= new Vector3(0,targetAngle,0);

        //transform.LookAt(tracker.target.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(localTarget), 0.1f);

    }

    private void LateUpdate()
    {
        //transform.LookAt(tracker.target.position);
        if (checkground() == false)
        {
            rigidbody.AddForce(new Vector3(0, -1, 0) * gravity * 3, ForceMode.Acceleration);
            transform.position += new Vector3(0, -0.1f, 0);
        }
    }

    public void LimitCut()
    {
        limit = limit / 2;
        Invoke("LimitReset",5f);
    }

    public void LimitCutShort()
    {
        limit = limit / 2;
        Invoke("LimitReset", 1.5f);
    }

    void LimitReset()
    {
        limit = limitset;
        gameObject.transform.GetChild(7).gameObject.GetComponent<Renderer>().material.SetColor("_Color",cartcolor);
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
}
