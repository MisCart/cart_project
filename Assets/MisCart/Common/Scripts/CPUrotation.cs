using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUrotation : MonoBehaviour {
    bool rflag = false;
    private float rotate;
    private int p = 0;
    AudioSource audio1;
   
    // Use this for initialization
    void Start () {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audio1 = audioSources[0];
        
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (rflag == true)
        {

            if (rotate < 360)
            {
                transform.Rotate(new Vector3(0, 5, 0));
                rotate += 5;
            }
            else
            {
                Invoke("rotatezero",0.5f);
                GetComponent<WaypointAgent>().enabled = true;
                rflag = false;
            }

            if(GetComponent<WaypointAgent>().enabled == false)
            {
               
                
                    GetComponent<WaypointAgent>().enabled = true;
                
            }
        }
    }
    void rotatezero()
    {
        rotate = 0;
    }
    public void startrotate()
    {
        Debug.Log("Hit");
        audio1.PlayOneShot(audio1.clip);
        Vector3 vct = new Vector3(Random.Range(-5,5), Random.Range(-5, 5), Random.Range(-5, 5));
        GetComponent<Rigidbody>().AddForce(vct*20,ForceMode.VelocityChange);
        
        //rflag = true;
        //gameObject.GetComponent<WaypointAgent>().enabled = false;
    }
}
