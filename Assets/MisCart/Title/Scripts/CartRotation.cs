using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Title.UI
{
    public class CartRotation : MonoBehaviour
    {
        public float duration = 3f;
        Tween tween;

        void OnEnable()
        {
            TweenKill();
            CartRotate();
        }

        void OnDisable() {
            TweenKill();
        }

        void CartRotate()
        {
            TweenKill();

            tween = gameObject.transform.GetComponent<RectTransform>().DORotate(
                new Vector3(0,360f,0),
                duration,
                RotateMode.FastBeyond360
            ).SetEase(Ease.Linear).SetLoops(-1);
        }

        void TweenKill()
        {
            gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            if(tween != null)
            {
                tween.Kill();
            }
        }

        void OnDestroy()
        {
            TweenKill();
        }
    }
}