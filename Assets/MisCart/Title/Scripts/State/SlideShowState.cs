using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviourMachine;
using MisCart;

namespace Title
{
	[AddComponentMenu("MisCart/Title/SlideShowState")]
	public class SlideShowState : StateBehaviour
	{
		void Start ()
		{
			TitleManager.UI.Start.SetActive(true);
			TitleManager.UI.SlideShow.SetActive(true);
			SoundController.PlayBGM(Model.BGM.Title);

            //スライドショー
			var slideShow = TitleManager.UI.SlideShow.slide();
			StartCoroutine(slideShow);
		}

		private void OnDisable() {
		}
	}
}
