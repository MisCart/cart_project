using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MisCart;

namespace Title.UI
{
	public class UICanvas : MonoBehaviour
	{
		[SerializeField] SplashScreen splashScreen;
		[SerializeField] SlideShow slideShow;
		[SerializeField] ClickToStart clickToStart;
		public SplashScreen SplashScreen { get { return splashScreen; } }
		public SlideShow SlideShow { get { return slideShow; } }
		public ClickToStart Start { get { return clickToStart; } }

		public void OnClick()
		{
			SoundController.PlaySE(Model.SE.ButtonClick);
			TitleManager.Front.Camera.gameObject.SetActive(true);
			TitleManager.Front.SetActive(true);
		}
	}
}
