using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBullet : MonoBehaviour {
    [SerializeField] private GameObject paintObj;
    public int sa = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0,-0.6f,0);
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            GameObject pObj = GameObject.Instantiate(paintObj) as GameObject;
            pObj.GetComponent<PiantObject>().Setsw(sa);
            pObj.transform.position = transform.position+new Vector3(0,-1.5f,0);
            Destroy(gameObject);
        }
    }
}
