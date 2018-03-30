using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Title.UI
{
	public class UICanvas : MonoBehaviour 
	{
		[SerializeField] SplashScreen splashScreen;
		[SerializeField] Loading loading;
		[SerializeField] SlideShow slideShow;
		[SerializeField] ClickToStart clickToStart;
		public SplashScreen SplashScreen { get { return splashScreen; } }
		public Loading Loading { get { return loading; } }
		public SlideShow SlideShow { get { return slideShow; } }
		public ClickToStart Start { get { return clickToStart; } }

		public bool IsScreen = true;

		public void OnClick()
		{
			if (!IsScreen)
			{
				TitleManager.Front.Camera.gameObject.SetActive(true);
				TitleManager.Front.SetActive(true);
			}
		}
	}
}
