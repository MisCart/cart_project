using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using BehaviourMachine;

namespace Title
{
    [AddComponentMenu("StandbyState")]
    public class StandbyState : TitleStateBehaviour
    {

        /// <summary>
        /// UIを一度全て非表示にさせる
        /// </summary>
        void Start ()
        {
    		TitleManager.UI.SplashScreen.SetActive(false);
    		TitleManager.UI.ClickToStart.SetActive(false);
            TitleManager.UI.StageSelect.SetActive(false);
            TitleManager.UI.CharacterSelectMenu.SetActive(false);
            TitleManager.UI.CartSelectMenu.SetActive(false);
    		TitleManager.Front.Camera.gameObject.SetActive(false);
    		TitleManager.Front.SetActive(false);
    		TitleManager.Model.SetActive(false);
    		TitleManager.Model.Character.SetActive(false);
            SendEvent("EndAction");
        }
        public override void OnClick(){}
		public override void OnBack(){}
    }
}