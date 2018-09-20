using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCartChara : MonoBehaviour {
    [SerializeField]private GameObject[] Carts;
    [SerializeField] private GameObject[] Charas;
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private Transform StartPos;
    private Transform CharaPos;
    // Use this for initialization
    void Awake () {
        SelectCart_Chara();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SelectCart_Chara()
    {
        int i = GameData.CartId-1;
        int p = GameData.CharacterId-1;
        GameObject car = GameObject.Instantiate(Carts[i]) as GameObject;
        car.transform.position = StartPos.position;
        MainCamera.GetComponent<AutoCam>().SetTarget(car.gameObject.transform.GetChild(0).gameObject);

        GameObject chara = GameObject.Instantiate(Charas[p]) as GameObject;
        //CharaPos.position = car.gameObject.transform.GetChild(1).gameObject.transform.position;
        chara.transform.position = car.gameObject.transform.GetChild(1).gameObject.transform.position;
        chara.transform.parent = car.gameObject.transform;


    }

    
}
