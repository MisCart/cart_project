using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Title.UI
{
	public class StartButton : MonoBehaviour 
	{
		//TODO ボタンを一度押したら処理が終わるまで押せないようにする。
		public void SwitchScene()
		{
			Debug.Log("Clickされたよ!");
			StartCoroutine(LoadScene());	
		}

		IEnumerator LoadScene()
		{
			//Now Loadingの表示
			TitleManager.UI.Loading.SetActive(true);

			var load = SceneManager.LoadSceneAsync("cart");
			load.allowSceneActivation = false;
			while (load.progress < 0.9f)
			{
				var progress = Math.Round(load.progress, 1)*100;
				TitleManager.UI.Loading.Text.text = "Now Loading..."+progress+"%";
				Debug.Log(load.progress);
				yield return null;
			}

			//ロード完了
			load.allowSceneActivation = true;
			TitleManager.UI.Loading.Text.text = "Now Loading...100%";
		}

	}
}
