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
        }

        public void OnMouseExit() {
            TitleManager.UI.Cart[(int)cart-1].SetActive(false);
            TitleManager.UI.CartSelectMenu.Questtion.SetActive(true);
        }

        public void OnClick() {
            var id = TitleManager.Board.GetIntVar("CartId");
			SoundController.PlaySE(Model.SE.Tap);
            id.Value = (int)cart;
        }
	}
}