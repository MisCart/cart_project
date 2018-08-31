using System.Collections;
using System;
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
		[SerializeField] StageSelect stageSelect;

		Action onClick;

		public SplashScreen SplashScreen { get { return splashScreen; } }
		public SlideShow SlideShow { get { return slideShow; } }
		public ClickToStart Start { get { return clickToStart; } }
		public StageSelect StageSelect {get { return stageSelect; } }

		public void OnClick()
		{
			if (onClick != null){
				onClick();
			}
		}

		public void SetOnClick(Action action=null){
			onClick = action;
		}
	}
}
