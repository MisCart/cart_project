using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviourMachine;
using MisCart;

namespace Title
{
	[AddComponentMenu("Title/CartSelectState")]
	public class CartSelectState : TitleStateBehaviour
	{
		void OnEnable ()
		{
            TitleManager.UI.CartSelectMenu.SetActive(true);
            TitleManager.UI.SetOnClick(() => OnClick());
            TitleManager.UI.SetOnBack(() => OnBack());
		}

		void Update() {
			if(blackboard.GetIntVar("CharaId").Value == 0){
				SendEvent("CharaId == 0");
			}
			if(blackboard.GetIntVar("CartId").Value > 0){
				SendEvent("CartId > 0");
			}
		}

        public override void OnClick(){}
		public override void OnBack(){
			blackboard.GetIntVar("CharaId").Value = 0;
			SoundController.PlaySE(Model.SE.Cansel);
		}

        void OnDisable() {
            TitleManager.UI.CartSelectMenu.SetActive(false);
			foreach (var item in TitleManager.UI.Cart)
			{
				item.SetActive(false);
			}
        }
	}
}
