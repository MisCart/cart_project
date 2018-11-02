using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MisCart;

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
            if (!GameData.isFinish)
            {
                SoundController.PlaySE(Model.SE.paintland);
            }
            
            pObj.transform.position = transform.position+new Vector3(0,-1.5f,0);
            Destroy(gameObject);
        }
    }
}
