using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUrotation : MonoBehaviour {
    bool rflag = false;
    private float rotate;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (rflag == true)
        {

            if (rotate < 360)
            {
                transform.Rotate(new Vector3(0, 5, 0));
                rotate += 5;
            }
            else
            {
                rotate = 0;
                GetComponent<WaypointAgent>().enabled = true;
                rflag = false;
            }
        }
    }

    void startrotate()
    {
        rflag = true;
        gameObject.GetComponent<WaypointAgent>().enabled = false;
    }
}
