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
		[SerializeField] CharacterSelectMenu characterSelectMenu;
		[SerializeField] StageSelect stageSelect;
		[SerializeField] GameObject character;
		[SerializeField] GameObject[] cart;

		Action onClick;
		Action onBack;

		public SplashScreen SplashScreen { get { return splashScreen; } }
		public SlideShow SlideShow { get { return slideShow; } }
		public ClickToStart ClickToStart { get { return clickToStart; } }
		public CharacterSelectMenu CharacterSelectMenu {get { return characterSelectMenu; } }
		public StageSelect StageSelect {get { return stageSelect; } }
		public GameObject Character { get { return character; } }
		public GameObject[] Cart { get { return cart; } }

		public void OnClick()
		{
			if (onClick != null){
				onClick();
			}
		}

		public void OnBack()
		{
			if (onBack != null){
				onBack();
			}
		}

		/// <summary>
		/// クリックしたときのの処理を設置
		/// </summary>
		public void SetOnClick(Action action=null){
			onClick = action;
		}

		/// <summary>
		/// 戻るボタンの処理を設置
		/// </summary>
		public void SetOnBack(Action action=null){
			onBack = action;
		}
	}
}
