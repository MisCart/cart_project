using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUrotation : MonoBehaviour {
    private WaypointAgent agent;
  
    // Use this for initialization
    void Start () {
        agent = GetComponent<WaypointAgent>();
    }

    public void startrotate()
    {
        Debug.Log("Hit");

       
        if (gameObject.tag == "CPU")
        {
            Vector3 vct = new Vector3(Random.Range(-5, 5), 1, Random.Range(-5, 5));
            GetComponent<Rigidbody>().AddForce(vct * 40, ForceMode.VelocityChange);
            agent.LimitCutShort();
        }
        else if (gameObject.tag == "Player")
        {
            Vector3 vct = new Vector3(Random.Range(-5, 5), 1, Random.Range(-5, 5));
            GetComponent<Rigidbody>().AddForce(vct * 40, ForceMode.VelocityChange);
            GetComponent<Controller>().LimitCutShort();
            CameraPlay.EarthQuakeShake();
        }
    }

   
}
