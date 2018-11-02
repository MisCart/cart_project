using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using MisCart;
using DG.Tweening;

public class itemsystem : MonoBehaviour {
    int itemnum=0;
    [SerializeField]
    private float colaspeed;
    public Transform itempos;
    public Transform itempos2;
    public GameObject gcolaitem;
    public GameObject rcolaitem;
    [SerializeField]private GameObject codeitem;
  
    private GameObject DVDimage;
    private GameObject CDimage;
    private GameObject Codeimage;
    private GameObject Specialimage;
    private GameObject Specialimage2;
    private GameObject Specialimage3;
    GameObject nearestCPU;
    bool gcola = false;
    bool rcola=false;
    
    bool code = false;
    private int color = 1;

    [SerializeField] private Animator mischan;

    private GameObject ItemSellecter;
    private Image L1text;


    GameObject[] tagobjs;
    float mindis = 1000;
    private bool special = false;
    private bool useItem = false;

    public void GetOtherItem(int i)
    {
        if (i == 1)
        {
            
            gcola=true;
        }
        else if (i == 2)
        {
            rcola=true;
        }
        else if (i == 3)
        {
            code=true;
        }
        else
        {
            special=true;
        }
    }

    public bool GetItemHave(int i)
    {
        if (i == 1)
        {
            return gcola;
        }
        else if (i == 2)
        {
            return rcola;
        }
        else if (i == 3)
        {
            return code;
        }
        else
        {
            return special;
        }
    }

    public void BeHacking()
    {
        gcola = false;
        rcola = false;
        code = false;
        special = false;
    }

    public void SpecialOff()
    {
        Specialimage.SetActive(false);
        Specialimage2.SetActive(false);
        Specialimage3.SetActive(false);
        special = false;
    }

        // Use this for initialization
        void Start () {
        ItemSellecter = GameObject.Find("UI");
        tagobjs = GameObject.FindGameObjectsWithTag("CPU");

        DVDimage = GameObject.Find("UI/Canvas/race/DVDimage(P)");
        CDimage = GameObject.Find("UI/Canvas/race/CDimage(P)");
        Codeimage = GameObject.Find("UI/Canvas/race/CODEimage(P)");
        Specialimage = GameObject.Find("UI/Canvas/race/Specialimage1");
        Specialimage2 = GameObject.Find("UI/Canvas/race/Specialimage2");
        Specialimage3 = GameObject.Find("UI/Canvas/race/Specialimage3");
        L1text= GameObject.Find("UI/Canvas/race/Itemtext").GetComponent<Image>();

    }
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.Space))||(Input.GetKeyDown(KeyCode.Joystick1Button4))||(Input.GetKey(KeyCode.Joystick1Button10)))
        {
            
            if (gcola == true)
            {
                //mischan.Play("ItemUse1");
                SoundController.PlaySE(Model.SE.cddvd2);
                GameObject bullet = GameObject.Instantiate(gcolaitem) as GameObject;
                bullet.transform.position = itempos.position;
                bullet.transform.forward = transform.forward;
                bullet.GetComponent<NavMeshAgent>().enabled = true;
                bullet.SendMessage("SetShot", gameObject);

                gcola = false;
            }

            if (rcola == true)
            {
                //mischan.Play("ItemUse1");
                SoundController.PlaySE(Model.SE.cddvd2);
                GameObject bullet2 = GameObject.Instantiate(rcolaitem) as GameObject;
                //bullet.AddComponent<NavMeshAgent>();
                Vector3 force;
                force = this.gameObject.transform.forward * colaspeed;
                bullet2.transform.position = itempos.position;
                bullet2.GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);
                bullet2.GetComponent<NavMeshAgent>().enabled = true;
                foreach (GameObject obj in tagobjs)
                {
                    float dis = Vector3.Distance(transform.position, obj.transform.position);
                    if (Vector3.Angle((obj.transform.position - transform.position).normalized, transform.forward) <= 90f)
                    {
                        if (dis < mindis)
                        {
                            nearestCPU = obj;
                            mindis = dis;
                        }
                    }

                }

                if (mindis == 1000)
                {
                    //nearestCPU = null;
                }
                mindis = 1000;

                bullet2.SendMessage("Settarget", nearestCPU);
                bullet2.SendMessage("SetShot", gameObject);

                //bullet2.transform.position = itempos.position;
                //bullet2.GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);

                rcola = false;
            }
            if (code == true)
            {
                SoundController.PlaySE(Model.SE.setup1);
                GameObject _code = GameObject.Instantiate(codeitem) as GameObject;
                _code.transform.position = itempos2.position;

                code = false;
            }
            if (special == true)
            {
                GetComponent<SpecialItem>().UseSpecialItem();
                //special = false;
            }

            DOTween.To(
                    () => color,          // 何を対象にするのか
                    color => L1text.color = new Color(color, 0, 0),   // 値の更新
                    0,                  // 最終的な値
                    2.0f                  // アニメーション時間
                    );
        }
    

        if (gcola == true)
        {
            //itemtext.GetComponent<Text>().text = "Cola(G)";
            CDimage.SetActive(true);
        }else if (rcola == true)
        {
            //itemtext.GetComponent<Text>().text = "Cola(R)";
            DVDimage.SetActive(true);
            
        }else if (code == true)
        {
            //itemtext.GetComponent<Text>().text = "Muteki";
            Codeimage.SetActive(true);
        }else if (special==true)
        {
            if (GetComponent<SpecialItem>().GetWhichCart() == 1)
            {
                Specialimage.SetActive(true);
            }else if(GetComponent<SpecialItem>().GetWhichCart() == 2)
            {
                Specialimage2.SetActive(true);
            }
            else if (GetComponent<SpecialItem>().GetWhichCart() == 3)
            {
                Specialimage3.SetActive(true);
            }

        }
        else
        {
            //itemtext.GetComponent<Text>().text = "";
            DVDimage.SetActive(false);
            CDimage.SetActive(false);
            Codeimage.SetActive(false);
            Specialimage.SetActive(false);
            Specialimage2.SetActive(false);
            Specialimage3.SetActive(false);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if ((gcola==false)&&(rcola==false)&&(code==false)&&(special==false))
        {


            if (col.gameObject.tag == "item")
            {
                col.gameObject.SendMessage("itemcollision");
                //itemnum = Random.Range(1, 3);
                ItemSellecter.GetComponent<ItemSellect>().SellectStart();

            }
        }
    }

    public void sellectitem()
    {
        itemnum = Random.Range(1, 5);

        if (itemnum == 1)
        {
            gcola = true;
        }
        else if (itemnum == 2)
        {
            rcola = true;
        }

        else if (itemnum == 3)
        {
            code = true;
        }
        else if (itemnum == 4)
        {
            special = true;
        }else if (itemnum == 5)
        {
            Debug.Log("No.5");
        }
    }


    public void Debug_sellectitem(int num)
    {
        //itemnum = Random.Range(1, 5);

        if (num == 1)
        {
            gcola = true;
        }
        else if (num == 2)
        {
            rcola = true;
        }

        else if (num == 3)
        {
            code = true;
        }
        else if (num == 4)
        {
            special = true;
        }
        else if (num == 5)
        {
            Debug.Log("No.5");
        }
    }


}
