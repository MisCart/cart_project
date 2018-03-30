using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Title.UI
{
	public class ChangeScene : MonoBehaviour 
	{
		public enum GameScene
		{
			Title,
			cart,
			sibazono
		}

		public GameScene gameScene;
		public void SwitchScene()
		{
			StartCoroutine(LoadScene());	
		}

		IEnumerator LoadScene()
		{
			//一度ボタンを押したら押せないようにする
			gameObject.GetComponent<Image>().raycastTarget = false;

			var scene = gameScene.ToString();
			var parentScene = SceneManager.LoadSceneAsync(scene);
			parentScene.allowSceneActivation = false;

			var additiveScene = SceneManager.LoadSceneAsync("GameUI", LoadSceneMode.Additive);
			additiveScene.allowSceneActivation = false;

			while (parentScene.progress < 0.9f && additiveScene.progress < 0.9f)
			{
				yield return null;
			}

			//ロード完了
			additiveScene.allowSceneActivation = true;
			parentScene.allowSceneActivation = true;
		}

	}
}
