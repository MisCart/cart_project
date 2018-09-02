using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviourMachine;
using MisCart;

namespace Title
{
	[AddComponentMenu("CharacterSelectState")]
	public class CharacterSelectState : TitleStateBehaviour
	{
		void OnEnable ()
		{
            TitleManager.UI.CharacterSelect.SetActive(true);
			TitleManager.Model.SetActive(true);
            TitleManager.UI.SetOnClick(() => OnClick());
            TitleManager.UI.SetOnBack(() => OnBack());
		}

        public override void OnClick()
		{
		}

        public override void OnBack()
		{
			TitleManager.Model.SetActive(false);
			TitleManager.UI.CharacterSelect.SetActive(false);
			SendEvent("EndAction");
		}

		void Update() {
			if(blackboard.GetIntVar("CharaId").Value > 0){
				SendEvent("CharaId > 0");
			}
		}

		void OnDisable() {
			TitleManager.Model.Character.SetActive(false);
			TitleManager.Model.SetActive(false);
			TitleManager.UI.CharacterSelect.SetActive(false);
		}
	}
}
