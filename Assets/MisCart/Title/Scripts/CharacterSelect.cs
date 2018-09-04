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
            TitleManager.UI.Character.SetActive(true);
            TitleManager.UI.CharacterSelectMenu.Questtion.SetActive(false);
        }

        public void OnMouseExit() {
            TitleManager.UI.Character.SetActive(false);
            TitleManager.UI.CharacterSelectMenu.Questtion.SetActive(true);
        }

        public void OnClick() {
            var id = TitleManager.Board.GetIntVar("CharaId");
            SoundController.PlaySE(Model.SE.Tap);
            id.Value = (int)chara;
        }
	}
}
