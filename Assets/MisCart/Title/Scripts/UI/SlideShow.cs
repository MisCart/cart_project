using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Title.UI
{
	public class SlideShow : MonoBehaviour
	{
        [SerializeField] Sprite[] images;

        [Space(5f)]
        
        [SerializeField] GameObject prevImageObject;
        [SerializeField] GameObject nextImageObject;

        [Space(5f)]

        public int waitTime = 5;
        public float changeSlideTime = 0.5f;

        Image prevImage;
        Image nextImage;

        Color visible = new Color(1f, 1f, 1f, 1f);
        Color invisible = new Color(1f, 1f, 1f, 0f);

		public void SetActive(bool value)
		{
			gameObject.SetActive(value);
		}

        public IEnumerator slide()
        {
            int count = 0;
            int length = images.Length;

            bool fadein = false;
            bool fadeout = false;

            prevImage = prevImageObject.GetComponent<Image>();
            nextImage = nextImageObject.GetComponent<Image>();
            
            //スプラッシュスクリーンが終わるまで待機
            while(!TitleManager.UI.SplashScreen.IsScreen) { yield return null; }

            while(count < length)
            {
                //画像をセット
                prevImage.sprite = images[count];
                nextImage.sprite = images[(count+1) % length];

                //fadeout
                DOTween.ToAlpha(
                    () => prevImage.color,
                    color => prevImage.color = color,
                    0f,
                    changeSlideTime
                ).OnComplete(() => fadeout = true);

                //fadein
                DOTween.ToAlpha(
                    () => nextImage.color,
                    color => nextImage.color = color,
                    1f,
                    changeSlideTime
                ).OnComplete(() => fadein = true);

                while(fadeout == false || fadein == false){ yield return null; }

                prevImageObject.SetActive(false);
                prevImage.sprite = nextImage.sprite;
                prevImage.color = visible;
                prevImageObject.SetActive(true);

                nextImageObject.SetActive(false);
                nextImage.color = invisible;
                nextImageObject.SetActive(true);

                yield return new WaitForSeconds(5);
                
                count++;
                fadein = false;
                fadeout = false;

                //スライドが最後までいったらリセットする
                if(count == images.Length)
                {
                    count = 0;
                }
            }
        }
	}
}