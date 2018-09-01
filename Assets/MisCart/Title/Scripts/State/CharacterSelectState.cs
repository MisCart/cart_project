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
            TitleManager.UI.SetOnClick(() => OnClick());
            TitleManager.UI.SetOnBack(() => OnBack());
		}

        public override void OnClick()
		{
		}

        public override void OnBack()
		{
			TitleManager.UI.CharacterSelect.SetActive(false);
			SendEvent("EndAction");
		}
	}
}
