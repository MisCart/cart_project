using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class kasoru : MonoBehaviour {

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(float x, float y);

    private float xPos;
    private float yPos;
	// Use this for initialization
	void Start () {
        xPos = Input.mousePosition.x;
        yPos = Input.mousePosition.y;
        Debug.Log(xPos+" "+yPos);

    }
	
	// Update is called once per frame
	void Update () {
        xPos = Input.mousePosition.x;
        yPos = Input.mousePosition.y;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xPos++;
            SetCursorPos(xPos,0);      
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xPos--;
            SetCursorPos(xPos, yPos);           
        }
       
        Debug.Log(xPos + " " + yPos);
    }
}
