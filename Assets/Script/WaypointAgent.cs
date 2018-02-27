using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
[RequireComponent(typeof(WaypointProgressTracker))]
public class WaypointAgent : MonoBehaviour {
    private WaypointProgressTracker tracker = null;

    [SerializeField, Range(0, 500)]
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



    new private Rigidbody rigidbody;
  
    float limit = 60f;
    float lPower = 60f;

    // Use this for initialization
    void Start () {
       
        tracker = GetComponent<WaypointProgressTracker>();
        rigidbody = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate() {



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

        Vector3 localTarget = tracker.target.position - transform.position;

        float targetAngle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        //float steer = Mathf.Clamp(targetAngle * 0.01f, -1, 1)* Mathf.Sign(rigidbody.velocity.magnitude * 2.23693629f);
        
        //float m_SteerAngle = steer * SteerLevel;
        


        transform.rotation = Quaternion.Euler(0,targetAngle,0);
      
      

    }
}
