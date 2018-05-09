using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI
{
	public class GameUIManager : SingletonMonoBehaviour<GameUIManager>
	{
		[SerializeField] UICanvas uiCanvas;
		public static UICanvas UI { get { return Instance.uiCanvas; } }

		public static bool IsCounting()
		{
			if (HasInstance)
			{
				return UI.IsCountDown;
			}
			return false;
		}
	}
}