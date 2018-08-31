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
            TitleManager.UI.SetOnClick(() => OnClick());

            //スライドショー
			var slideShow = TitleManager.UI.SlideShow.slide();
			StartCoroutine(slideShow);

			SoundController.PlayBGM(Model.BGM.Title);
		}

        public void OnClick()
		{
			SoundController.PlaySE(Model.SE.ButtonClick);
			TitleManager.UI.StageSelect.SetActive(true);
		}

        void OnDisable() {
            TitleManager.UI.SetOnClick();
        }
	}
}
