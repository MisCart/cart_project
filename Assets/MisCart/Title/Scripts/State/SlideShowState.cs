using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviourMachine;
using MisCart;

namespace Title
{
	[AddComponentMenu("Title/SlideShowState")]
	public class SlideShowState : TitleStateBehaviour
	{
		void Start()
		{
			SoundController.PlayBGM(Model.BGM.Title);
		}

		void OnEnable()
		{
			TitleManager.UI.ClickToStart.SetActive(true);
            TitleManager.UI.SetOnClick(() => OnClick());
            TitleManager.UI.SetOnBack(() => OnBack());
		}

		void OnDisable()
		{
    		TitleManager.UI.ClickToStart.SetActive(false);
			SoundController.StopBGM(Model.BGM.Title, 0.5f);
			SoundController.PlayBGM(Model.BGM.TitleSelect);
		}

        public override void OnClick()
		{
			SoundController.PlaySE(Model.SE.Select);
			TitleManager.UI.CharacterSelectMenu.SetActive(true);
			SendEvent("EndAction");
		}

		public override void OnBack(){}
	}
}
