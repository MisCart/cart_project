using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSelectCar : MonoBehaviour {
    [SerializeField] private int carnum=1;
    [SerializeField] private int charanum = 1;
    // Use this for initialization
    void Awake () {
        GameData.CartId = carnum;
        GameData.CharacterId = charanum;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
