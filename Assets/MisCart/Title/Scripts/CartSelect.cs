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
        }

        public void OnMouseExit() {
            TitleManager.UI.Cart[(int)cart-1].SetActive(false);
        }

        public void OnClick() {
            var id = TitleManager.Board.GetIntVar("CartId");
            id.Value = (int)cart;
        }
	}
}
