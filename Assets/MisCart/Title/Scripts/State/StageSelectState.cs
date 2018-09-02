using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviourMachine;
using MisCart;

namespace Title
{
	[AddComponentMenu("StageSelectState")]
	public class StageSelectState : TitleStateBehaviour
	{
		void OnEnable ()
		{
            TitleManager.UI.StageSelectMenu.SetActive(true);
            TitleManager.UI.SetOnClick(() => OnClick());
            TitleManager.UI.SetOnBack(() => OnBack());
		}

		void Update() {
			if(blackboard.GetIntVar("CartId").Value == 0){
				SendEvent("CartId == 0");
			}
		}

        public override void OnClick(){}
		public override void OnBack(){
			blackboard.GetIntVar("CartId").Value = 0;
		}

        void OnDisable() {
            TitleManager.UI.StageSelectMenu.SetActive(false);
        }
	}
}
