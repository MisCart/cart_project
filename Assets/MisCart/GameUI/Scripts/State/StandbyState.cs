using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using BehaviourMachine;

namespace GameUI
{
    [AddComponentMenu("GameUI/StandbyState")]
    public class StandbyState : GameUIStateBehaviour
    {

        void Start ()
        {
            GameUIManager.UI.CountDownObject.SetActive(false);
            GameUIManager.Board.GetBoolVar("IsCounting").Value = true;
            SendEvent("StartCountDown");
        }
        public override void OnClick(){}
		public override void OnBack(){}
    }
}