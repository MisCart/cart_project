using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUrotation : MonoBehaviour {
    bool rflag = false;
    private float rotate;
    private int p = 0;
    AudioSource audio1;
    private WaypointAgent agent;

    // Use this for initialization
    void Start () {
        agent = GetComponent<WaypointAgent>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
    }
    void rotatezero()
    {
        rotate = 0;
    }
    public void startrotate()
    {
        Debug.Log("Hit");

       
        if (gameObject.tag == "CPU")
        {
            Vector3 vct = new Vector3(Random.Range(-5, 5), 5, Random.Range(-5, 5));
            GetComponent<Rigidbody>().AddForce(vct * 20, ForceMode.VelocityChange);
            agent.LimitCutShort();
        }
        else if (gameObject.tag == "Player")
        {
            Vector3 vct = new Vector3(Random.Range(-5, 5), 1, Random.Range(-5, 5));
            GetComponent<Rigidbody>().AddForce(vct * 20, ForceMode.VelocityChange);
            GetComponent<Controller>().LimitCutShort();
        }
    }
}
