using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Title
{
	public class TitleManager : SingletonMonoBehaviour<TitleManager>
	{
		[SerializeField] UI.UICanvas uiCanvas;
		public static UI.UICanvas UI { get { return Instance.uiCanvas; } }
	}
}