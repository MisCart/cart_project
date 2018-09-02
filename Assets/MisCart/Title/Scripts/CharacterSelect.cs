using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Transition;
using MisCart;

namespace Title
{
	public class CharacterSelect : MonoBehaviour
	{
		public Model.GameCharacter chara;

        public void OnMouseEnter() {
            TitleManager.Model.Character.SetActive(true);
        }

        public void OnMouseExit() {
            TitleManager.Model.Character.SetActive(false);
        }

        public void OnClick() {
            var id = TitleManager.Board.GetIntVar("CharaId");
            id.Value = (int)chara;
        }
	}
}
