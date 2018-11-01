using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

namespace GameUI
{
	public class GameUIManager : SingletonMonoBehaviour<GameUIManager>
	{
		[SerializeField] UICanvas uiCanvas;
		[SerializeField] GameUISound sound;
		Blackboard board;
		public static UICanvas UI { get { return Instance.uiCanvas; } }
		public static GameUISound Sound { get { return Instance.sound; } }
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

		public static void StartAnimation(){
			if (HasInstance){
				Board.GetBoolVar("SetAnimation").Value = true;
			}
		}

		public static void StartCountDown(){
			if (HasInstance){
				Board.GetBoolVar("SetCountDown").Value = true;
			}
		}
	}
}