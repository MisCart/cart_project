using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Transition;
using MisCart;

namespace Title
{
	public class ChangeScene : MonoBehaviour
	{
		public Model.GameScenes scene;
		Button btn;

		void Start () {
			btn = GetComponent<Button>();
		}

		public void OnClick()
		{
			SoundController.PlaySE(Model.SE.Select);
			SoundController.StopBGM(Model.BGM.TitleSelect, 0.5f);
			btn.interactable = false;
			GameData.CharacterId = TitleManager.Board.GetIntVar("CharaId").Value;
			GameData.CartId = TitleManager.Board.GetIntVar("CartId").Value;

			//チュートリアルシーンにはUIがそのまま入っているのでGameUIを呼び出さない
			if(scene == Model.GameScenes.Tutorial){
				SceneLoader.LoadScene(scene);
			}else{
				SceneLoader.LoadScene(scene, new[] { Model.GameScenes.GameUI });
			}
		}
	}
}
