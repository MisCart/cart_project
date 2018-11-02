using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MisCart;

public class PaintDan : MonoBehaviour {
    [SerializeField] private GameObject paintB;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetPaintBullet(GameObject gameObj)
    {
        paintB = gameObj;
    }


    public void PaintStart()//Player用
    {
        GameObject bullet = GameObject.Instantiate(paintB) as GameObject;
        bullet.SetActive(true);
        Vector3 force;
        if (gameObject.tag == "Player")
        {
            bullet.GetComponent<PaintBullet>().sa = 1;
        }
        else if (gameObject.tag == "CPU")
        {
            bullet.GetComponent<PaintBullet>().sa = 0;
        }
        bullet.transform.position = transform.position+new Vector3(0,2,0);
        force = (this.gameObject.transform.forward +new Vector3(0,0.4f,0))* 80;
        bullet.GetComponent<Rigidbody>().AddForce(force,ForceMode.VelocityChange);
        if (!GameData.isFinish)
        {
            SoundController.PlaySE(Model.SE.paintfire);
        }
        if (gameObject.tag == "Player")
        {
            GetComponent<itemsystem>().SpecialOff();
        }else if (gameObject.tag=="CPU")
        {
            GetComponent<itemsystemforCPU>().SpecialOff();
        }
       
    }
}
