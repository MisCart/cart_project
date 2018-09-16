using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

namespace Title
{
	public class TitleManager : SingletonMonoBehaviour<TitleManager>
	{
		[SerializeField] UI.UICanvas uiCanvas;
		[SerializeField] UI.FrontCanvas frontCanvas;
		Blackboard board;
		public static UI.UICanvas UI { get { return Instance.uiCanvas; } }
		public static UI.FrontCanvas Front { get { return Instance.frontCanvas; } }
		public static Blackboard Board { get { return Instance.board; } }

		void Start() {
			board = GetComponent<Blackboard>();
		}
	}
}