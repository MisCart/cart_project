using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviourMachine;

namespace Title
{
	[AddComponentMenu("MisCart/Title/TitleAnimationState")]
	public class TitleAnimationState : StateBehaviour
	{
		void Start ()
		{
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
