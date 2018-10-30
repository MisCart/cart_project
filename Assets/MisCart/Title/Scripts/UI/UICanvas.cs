using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MisCart;

namespace Title.UI
{
	public class UICanvas : MonoBehaviour
	{
		[SerializeField] SplashScreen splashScreen;
		[SerializeField] ClickToStart clickToStart;
		[SerializeField] CharacterSelectMenu characterSelectMenu;
		[SerializeField] CartSelectMenu cartSelectMenu;
		[SerializeField] StageSelectMenu stageSelectMenu;
		[SerializeField] Image coverImage;
		[SerializeField] GameObject[] character;
		[SerializeField] GameObject[] cart;

		Action onClick;
		Action onBack;

		public SplashScreen SplashScreen { get { return splashScreen; } }
		public ClickToStart ClickToStart { get { return clickToStart; } }
		public CharacterSelectMenu CharacterSelectMenu {get { return characterSelectMenu; } }
		public CartSelectMenu CartSelectMenu {get { return cartSelectMenu; } }
		public StageSelectMenu StageSelectMenu {get { return stageSelectMenu; } }
		public Image CoverImage { get { return coverImage; } }
		public GameObject[] Character { get { return character; } }
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
