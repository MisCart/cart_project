using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MisCart;
using DG.Tweening;

public class SlipItem : MonoBehaviour {
    // Use this for initialization
    private bool active = false;
    private float R = 360;
	void Start () {

        Invoke("StartEffect", 1f);
    }
	
    private void StartEffect()
    {
        active = true;
    }
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Controller>().LimitCut();
                
                SoundController.PlaySE(Model.SE.encount1);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                other.gameObject.GetComponent<correctDirection>().Rotate();
                other.gameObject.GetComponent<Controller>().slipitem();

                float angleDir2 = other.transform.eulerAngles.y * (Mathf.PI / 180.0f);
                Vector3 dir2 = new Vector3(Mathf.Sin(angleDir2), 0.0f, Mathf.Cos(angleDir2));
               
                DOTween.To(
                    () => R,          // 何を対象にするのか
                    R => other.transform.rotation = Quaternion.AngleAxis(R, new Vector3(0, 1, 0)),   // 値の更新
                    - angleDir2*60,                  // 最終的な値
                    1.0f                  // アニメーション時間
                    );
                Invoke("Dess", 2);
            }
            else if (other.gameObject.tag == "CPU")
            {
                other.gameObject.GetComponent<WaypointAgent>().LimitCut();
                SoundController.PlaySE(Model.SE.encount1);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                DOTween.To(
                   () => R,          // 何を対象にするのか
                   R => other.transform.eulerAngles = new Vector3(0, R, 0),   // 値の更新
                   -360,                  // 最終的な値
                   2.0f                  // アニメーション時間
                   );
                Invoke("Dess", 2);
            }
        }
    }
    void Dess()
    {
        Destroy(gameObject);
    }

}
