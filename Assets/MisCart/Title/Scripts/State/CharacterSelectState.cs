using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviourMachine;
using MisCart;

namespace Title
{
	[AddComponentMenu("Title/CharacterSelectState")]
	public class CharacterSelectState : TitleStateBehaviour
	{
		void OnEnable ()
		{
            TitleManager.UI.CharacterSelectMenu.SetActive(true);
			TitleManager.UI.CoverImage.gameObject.SetActive(true);
            TitleManager.UI.SetOnClick(() => OnClick());
            TitleManager.UI.SetOnBack(() => OnBack());
		}

        public override void OnClick()
		{
		}

        public override void OnBack()
		{
			SendEvent("EndAction");
			SoundController.PlaySE(Model.SE.Cansel);
			SoundController.StopBGM(Model.BGM.TitleSelect, 0.5f);
			SoundController.PlayBGM(Model.BGM.Title);
			TitleManager.UI.CoverImage.gameObject.SetActive(false);
		}

		void Update() {
			if(blackboard.GetIntVar("CharaId").Value > 0){
				SendEvent("CharaId > 0");
			}
		}

		void OnDisable() {
			foreach (var item in TitleManager.UI.Character)
			{
				item.SetActive(false);
			}
			TitleManager.UI.CharacterSelectMenu.SetActive(false);
		}
	}
}
