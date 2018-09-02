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
            TitleManager.UI.CharacterSelectMenu.SetActive(true);
            TitleManager.UI.SetOnClick(() => OnClick());
            TitleManager.UI.SetOnBack(() => OnBack());
		}

        public override void OnClick()
		{
		}

        public override void OnBack()
		{
			SendEvent("EndAction");
		}

		void Update() {
			if(blackboard.GetIntVar("CharaId").Value > 0){
				SendEvent("CharaId > 0");
			}
		}

		void OnDisable() {
			TitleManager.UI.Character.SetActive(false);
			TitleManager.UI.CharacterSelectMenu.SetActive(false);
		}
	}
}
