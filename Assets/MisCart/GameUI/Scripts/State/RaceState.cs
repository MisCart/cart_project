using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using BehaviourMachine;

namespace GameUI
{
    [AddComponentMenu("GameUI/RaceState")]
    public class RaceState : GameUIStateBehaviour
    {
        public override void OnClick(){}
		public override void OnBack(){}

        void Start ()
        {
            GameUIManager.UI.SetOnClick(() => OnClick());
            GameUIManager.UI.SetOnBack(() => OnBack());
        }

        void Update() {
            if(GameUIManager.Board.GetBoolVar("SetAnimation").Value){
                SendEvent("StartAnimation");
            }
        }

    }
}