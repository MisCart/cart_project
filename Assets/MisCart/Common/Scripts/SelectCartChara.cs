using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCartChara : MonoBehaviour {
    [SerializeField]private GameObject[] Carts;
    [SerializeField] private GameObject[] Charas;
    [SerializeField] private GameObject[] CPUs;
    [SerializeField] private GameObject[] CPUcart;
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private Transform StartPos;
    [SerializeField] private ChargingGage _charginggage;
    private Transform CharaPos;
    [SerializeField]private int Setcart;
    [SerializeField] private int SetChara;
    [SerializeField] private bool debug = false;// Use this for initialization
    private GameObject car;
    void Awake () {
        SetCPUCart_Chara();
        Debug.Log("CharaID: " + (GameData.CharacterId-1));
        Debug.Log("CartID: " + (GameData.CartId - 1));
        if (debug)
        {
            GameData.CartId = Setcart;
            GameData.CharacterId = SetChara;
        }
        SelectCart_Chara();
        

    }
	
	// Update is called once per frame
	void Update () {
        //debug用
        if (debug)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                car.GetComponent<itemsystem>().Debug_sellectitem(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                car.GetComponent<itemsystem>().Debug_sellectitem(2);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                car.GetComponent<itemsystem>().Debug_sellectitem(3);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                car.GetComponent<itemsystem>().Debug_sellectitem(4);
                car.GetComponent<SpecialItem>().Debug_SetNum(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                car.GetComponent<itemsystem>().Debug_sellectitem(4);
                car.GetComponent<SpecialItem>().Debug_SetNum(2);
            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                car.GetComponent<itemsystem>().Debug_sellectitem(4);
                car.GetComponent<SpecialItem>().Debug_SetNum(3);
            }
        }
    }

    private void SelectCart_Chara()
    {
        int i = GameData.CartId-1;
        int p = GameData.CharacterId-1;
        //GameObject car = GameObject.Instantiate(Carts[i]) as GameObject;
        //Debug.Log(GameData.CartId);
        car = Carts[i];
        car.SetActive(true);
        car.transform.position = StartPos.position;
        MainCamera.GetComponent<AutoCam>().SetTarget(car.gameObject.transform.GetChild(0).gameObject);

        //GameObject chara = GameObject.Instantiate(Charas[p]) as GameObject;
        GameObject chara = Charas[p];
        
        //chara.SetActive(true);
        chara.transform.position = car.gameObject.transform.GetChild(1).gameObject.transform.position;
        chara.transform.parent = car.gameObject.transform;

        _charginggage.SetPlayer(car);


    }

    private void SetCPUCart_Chara()
    {
        foreach(GameObject cpu in CPUs)
        {
            cpu.GetComponent<MeshRenderer>().enabled = false;
            var num = Random.Range(1,7);
            var numchara = Random.Range(1, 7);
            var cpucar = GameObject.Instantiate(CPUcart[num-1]) as GameObject;
            var cpuchara = GameObject.Instantiate(Charas[numchara - 1]) as GameObject;
            cpuchara.transform.parent = cpu.gameObject.transform;
            cpuchara.transform.position = cpu.transform.position + new Vector3(0,-1.7f,1.7f);
            cpucar.transform.parent = cpu.gameObject.transform;
            if (num >= 4)//middle
            {
                cpucar.transform.position = cpu.transform.position + new Vector3(-1.55f, - 0.95f, 1.3f);
            }
            else//light
            {
                cpucar.transform.position = cpu.transform.position + new Vector3(-0.6f ,- 0.37f, 0);
            }
            //cpucar.transform.parent = cpu.gameObject.transform;

            cpu.GetComponent<itemsystemforCPU>().SetCartType(num % 3,cpucar);
            cpu.GetComponent<WaypointAgent>().enabled=true;

            
        }
    }

  



    
}
