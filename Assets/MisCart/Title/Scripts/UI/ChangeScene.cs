using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
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
			//Now Loadingの表示
			TitleManager.UI.Loading.SetActive(true);

			var scene = gameScene.ToString();
			var load = SceneManager.LoadSceneAsync(scene);
			load.allowSceneActivation = false;
			while (load.progress < 0.9f)
			{
				var progress = Math.Round(load.progress, 1)*100;
				TitleManager.UI.Loading.Text.text = "Now Loading..."+progress+"%";
				yield return null;
			}

			//ロード完了
			load.allowSceneActivation = true;
			TitleManager.UI.Loading.Text.text = "Now Loading...100%";
		}

	}
}
