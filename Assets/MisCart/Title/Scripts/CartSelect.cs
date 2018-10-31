using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Transition;
using MisCart;

namespace Title
{
	public class CartSelect : MonoBehaviour
	{
		public Model.GameCart cart;

        public void OnMouseEnter() {
            TitleManager.UI.Cart[(int)cart-1].SetActive(true);
            TitleManager.UI.CartSelectMenu.Questtion.SetActive(false);

            if((int)cart>3){
                TitleManager.UI.Weight.text = "Weight / 重量級";
            }else{
                TitleManager.UI.Weight.text = "Weight / 軽量級";
            }

            if((int)cart == 1 || (int)cart == 4){
                TitleManager.UI.Team.text = "Team / CG";
            } else if ((int)cart == 2 || (int)cart == 5){
                TitleManager.UI.Team.text = "Team / MIDI";
            } else if ((int)cart == 3 || (int)cart == 6){
                TitleManager.UI.Team.text = "Team / プログラミング";
            }
        }

        public void OnMouseExit() {
            TitleManager.UI.Cart[(int)cart-1].SetActive(false);
            TitleManager.UI.CartSelectMenu.Questtion.SetActive(true);
            TitleManager.UI.Weight.text = "Weight / ???";
            TitleManager.UI.Team.text = "Team / ???";
        }

        public void OnClick() {
            var id = TitleManager.Board.GetIntVar("CartId");
			SoundController.PlaySE(Model.SE.Tap);
            id.Value = (int)cart;
        }
	}
}
