using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Title.UI
{
	public class UICanvas : MonoBehaviour 
	{
		[SerializeField] StartButton startButton;
		[SerializeField] SplashScreen splashScreen;
		[SerializeField] Loading loading;
		[SerializeField] SlideShow slideShow;
		public StartButton StartButton { get { return startButton; } }
		public SplashScreen SplashScreen { get { return splashScreen; } }
		public Loading Loading { get { return loading; } }
		public SlideShow SlideShow { get { return slideShow; } }
	}
}
