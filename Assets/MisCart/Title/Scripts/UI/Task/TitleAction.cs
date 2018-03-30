using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Title.UI
{
	public class TitleAction : MonoBehaviour
	{
		void Start ()
		{
			//後から表示させるものを一度全て非表示にさせる
			TitleManager.UI.SplashScreen.SetActive(false);
			TitleManager.UI.Loading.SetActive(false);
			TitleManager.UI.SlideShow.SetActive(false);
			TitleManager.UI.Start.SetActive(false);
			TitleManager.Front.Camera.gameObject.SetActive(false);
			TitleManager.Front.SetActive(false);

			//スプラッシュスクリーン
			TitleManager.UI.SplashScreen.SetActive(true);
			var screen = TitleManager.UI.SplashScreen.Screen();
			StartCoroutine(screen);

			//背景のスライドショー
			TitleManager.UI.SlideShow.SetActive(true);
			var slideShow = TitleManager.UI.SlideShow.slide();
			StartCoroutine(slideShow);

			TitleManager.UI.Start.SetActive(true);
		}
	}
}
