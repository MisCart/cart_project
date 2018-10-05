using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Result
{
	public class ResultManager : SingletonMonoBehaviour<ResultManager>
	{
		[SerializeField] UICanvas uiCanvas;
		public static UICanvas UI { get { return Instance.uiCanvas; } }

	}
}