using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using BehaviourMachine;

namespace GameUI
{
    [AddComponentMenu("GameUI/StandbyState")]
    public class StandbyState : GameUIStateBehaviour
    {

        //初期化
        void Start ()
        {
            GameUIManager.UI.CountDownObject.SetActive(false);
            GameUIManager.UI.MessageBox.SetActive(false);
            GameUIManager.UI.MisChan.SetActive(false);
            GameUIManager.UI.ResultBox.SetActive(false);
            GameUIManager.UI.Cover.SetActive(false);
            GameUIManager.UI.SetOnClick(() => OnClick());
            GameUIManager.UI.SetOnBack(() => OnBack());
        }

        void Update() {
           if(GameUIManager.Board.GetBoolVar("SetAnimation").Value){
               SendEvent("StartAnimation");
           }
           if(GameUIManager.Board.GetBoolVar("SetCountDown").Value){
               SendEvent("StartCountDown");
           }
        }

        public override void OnClick(){}
		public override void OnBack(){}
    }
}