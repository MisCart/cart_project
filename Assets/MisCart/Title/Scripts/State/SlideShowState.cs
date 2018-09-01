using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviourMachine;
using MisCart;

namespace Title
{
	[AddComponentMenu("SlideShowState")]
	public class SlideShowState : TitleStateBehaviour
	{
		void Start()
		{
            //スライドショー
			var slideShow = TitleManager.UI.SlideShow.slide();
			StartCoroutine(slideShow);
			SoundController.PlayBGM(Model.BGM.Title);
		}

		void OnEnable()
		{
			TitleManager.UI.ClickToStart.SetActive(true);
			TitleManager.UI.SlideShow.SetActive(true);
            TitleManager.UI.SetOnClick(() => OnClick());
		}

        public override void OnClick()
		{
			SoundController.PlaySE(Model.SE.ButtonClick);
			TitleManager.UI.CharacterSelect.SetActive(true);
			SendEvent("EndAction");
		}

		public override void OnBack(){}

        void OnDisable() {
    		TitleManager.UI.ClickToStart.SetActive(false);
        }
	}
}
