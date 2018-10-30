using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Title.UI
{
    public class ClickToStart : MonoBehaviour
    {
        [SerializeField] CanvasGroup canvas;
        public float duration = 1f;
        Tween tween;

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        void OnEnable()
        {
            TweenKill();
            ChangeAlfa();
        }

        void OnDisable(){
            TweenKill();
        }

        void ChangeAlfa()
        {
            TweenKill();
            var sequence = DOTween.Sequence();
            sequence.AppendInterval(5f);
            sequence.Append(canvas.DOFade(0f, duration));
            sequence.Append(canvas.DOFade(1f, duration));
            sequence.SetLoops(-1);
            tween = sequence.Play();
        }

        void TweenKill()
        {
            if(tween != null)
            {
                tween.Kill();
            }
            canvas.alpha = 1f;
        }

        void OnDestroy()
        {
            TweenKill();
        }
    }
}