using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

namespace GameUI
{
	public class GameUIManager : SingletonMonoBehaviour<GameUIManager>
	{
		[SerializeField] UICanvas uiCanvas;
		Blackboard board;
		public static UICanvas UI { get { return Instance.uiCanvas; } }
		public static Blackboard Board { get { return Instance.board; } }

		void Start() {
			board = GetComponent<Blackboard>();
		}

		public static bool IsCounting()
		{
			if (HasInstance)
			{
				return Board.GetBoolVar("IsCounting").Value;
			}
			return false;
		}
	}
}