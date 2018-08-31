using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviourMachine;
using MisCart;

namespace Title
{
	[AddComponentMenu("MisCart/Title/SplashScreenState")]
	public class SplashScreenState : StateBehaviour
	{
		BoolVar isScreen;
		void Start ()
		{
			isScreen = blackboard.GetBoolVar("IsSplashScreen");
			TitleManager.UI.SplashScreen.SetActive(true);

			//スプラッシュスクリーン
			var screen = TitleManager.UI.SplashScreen.Screen(() => isScreen.Value = false);
			StartCoroutine(screen);
		}

		void Update()
		{
			if(!isScreen){
				SendEvent("EndAction");
			}
		}

		private void OnDisable() {
			TitleManager.UI.SplashScreen.SetActive(false);
		}
	}
}
