using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using BehaviourMachine;
using MisCart;

namespace Title
{
    [AddComponentMenu("Title/StandbyState")]
    public class StandbyState : TitleStateBehaviour
    {

        /// <summary>
        /// UIを一度全て非表示にさせる
        /// </summary>
        void Start ()
        {
    		TitleManager.UI.SplashScreen.SetActive(false);
    		TitleManager.UI.ClickToStart.SetActive(false);
            TitleManager.UI.StageSelectMenu.SetActive(false);
            TitleManager.UI.CharacterSelectMenu.SetActive(false);
            TitleManager.UI.CartSelectMenu.SetActive(false);
            TitleManager.UI.CoverImage.gameObject.SetActive(false);
    		TitleManager.Front.Camera.gameObject.SetActive(false);
    		TitleManager.Front.SetActive(false);

            if(GameData.CartId > 0 && GameData.CharacterId > 0){
                TitleManager.Board.GetIntVar("CharaId").Value = GameData.CharacterId;
                TitleManager.Board.GetIntVar("CartId").Value = GameData.CartId;
                SoundController.PlayBGM(Model.BGM.TitleSelect);

                SendEvent("SkipSelect");
            } else {
                SendEvent("EndAction");
            }
        }
        public override void OnClick(){}
		public override void OnBack(){}
    }
}