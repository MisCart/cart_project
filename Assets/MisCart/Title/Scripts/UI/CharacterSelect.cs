using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

namespace Title.UI
{
	public class CharacterSelect : MonoBehaviour
	{
        [SerializeField] CanvasGroup canvas;
        [SerializeField] RectTransform rect;
        Tween tween;

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        /// <summary>
        /// 中央に拡大+フェードで表示されるアニメーション
        /// </summary>
        void OnEnable()
        {
            TweenKill();
            Reset();

            var scale = rect.DOScale(
                new Vector3(1f, 1f, 1f),
                0.4f
            );
            var fade = canvas.DOFade(1f, 0.4f);

            var sequence = DOTween.Sequence();
            sequence.AppendInterval(0.1f);
            sequence.Append(scale);
            sequence.Join(fade);
            tween = sequence.Play();
        }

        void TweenKill()
        {
            if(tween != null)
            {
                tween.Kill();
            }
        }

        void OnDestroy()
        {
            TweenKill();
        }

        void Reset()
        {
            rect.localScale = new Vector3(0.9f, 0.9f, 1f);
            canvas.alpha = 0f;
        }
	}
}