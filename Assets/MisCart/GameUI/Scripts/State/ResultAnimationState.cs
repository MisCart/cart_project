using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using BehaviourMachine;
using Transition;
using MisCart;
using Model;

namespace GameUI
{
    [AddComponentMenu("GameUI/ResultAnimationState")]
    public class ResultAnimationState : GameUIStateBehaviour
    {

        void Start ()
        {
            GameUIManager.UI.MessageBox.SetActive(true);
            GameUIManager.UI.MisChan.SetActive(true);
            GameUIManager.UI.ResultBox.SetActive(true);
            GameUIManager.UI.Cover.SetActive(true);

            GameUIManager.UI.SetOnClick(() => OnClick());
            GameUIManager.UI.SetOnBack(() => OnBack());
            SetMessage();
            SetRank();
            PlaySound();

            GameUIManager.UI.StartTimeline();
        }

        /// <summary>
        /// 選んだキャラクターや順位に合わせて台詞を変える
        /// 1~3位なら勝利用の台詞、それ以外なら敗北用の台詞
        /// </summary>
        void SetMessage(){
            var id = GameData.CharacterId;
            if(id == 1){
                GameUIManager.UI.MisChan.GetComponent<Image>().sprite = GameUIManager.UI.MisChan.Images[0];
                if(GameData.FinishRank <= 3){
                    GameUIManager.UI.Message = CharacterMessage.misChanBlueWin;
                } else {
                    GameUIManager.UI.Message = CharacterMessage.misChanBlueWin;
                }
            }
            if(id == 2){
                GameUIManager.UI.MisChan.GetComponent<Image>().sprite = GameUIManager.UI.MisChan.Images[1];
                if(GameData.FinishRank <= 3){
                    GameUIManager.UI.Message = CharacterMessage.misChanGreenWin;
                } else {
                    GameUIManager.UI.Message = CharacterMessage.misChanGreenLose;
                }
            }
            if(id == 3){
                GameUIManager.UI.MisChan.GetComponent<Image>().sprite = GameUIManager.UI.MisChan.Images[2];
                if(GameData.FinishRank <= 3){
                    GameUIManager.UI.Message = CharacterMessage.misChanLightBlueWin;
                } else {
                    GameUIManager.UI.Message = CharacterMessage.misChanLightBlueLose;
                }
            }
            if(id == 4){
                GameUIManager.UI.MisChan.GetComponent<Image>().sprite = GameUIManager.UI.MisChan.Images[3];
                if(GameData.FinishRank <= 3){
                    GameUIManager.UI.Message = CharacterMessage.misChanPinkWin;
                } else {
                    GameUIManager.UI.Message = CharacterMessage.misChanPinkLose;
                }
            }
            if(id == 5){
                GameUIManager.UI.MisChan.GetComponent<Image>().sprite = GameUIManager.UI.MisChan.Images[4];
                if(GameData.FinishRank <= 3){
                    GameUIManager.UI.Message = CharacterMessage.misChanRedWin;
                } else {
                    GameUIManager.UI.Message = CharacterMessage.misChanRedLose;
                }
            }
            if(id == 6){
                GameUIManager.UI.MisChan.GetComponent<Image>().sprite = GameUIManager.UI.MisChan.Images[5];
                if(GameData.FinishRank <= 3){
                    GameUIManager.UI.Message = CharacterMessage.misChanYellowWin;
                } else {
                    GameUIManager.UI.Message = CharacterMessage.misChanYellowLose;
                }
            }
        }

        //順位のセット
        void SetRank(){
            if(GameData.FinishRank == 1){
                GameUIManager.UI.Rank.text = "1st";
            } else if(GameData.FinishRank == 2){
                GameUIManager.UI.Rank.text = "2nd";
            } else if(GameData.FinishRank == 3){
                GameUIManager.UI.Rank.text = "3rd";
            } else {
                GameUIManager.UI.Rank.text = GameData.FinishRank+"th";
            }
        }

        void PlaySound(){
            SoundController.StopAll();
            if(GameData.FinishRank <= 3){
                SoundController.PlayBGM(Model.BGM.Win);
            }else{
                SoundController.PlayBGM(Model.BGM.Lose);
            }
        }

        public override void OnClick(){
            SoundController.StopAll(0.3f);
			SoundController.PlaySE(Model.SE.Tap);
            SceneLoader.LoadScene(TransitionManager.CurrentGameScene, new[] { Model.GameScenes.GameUI });
        }
		public override void OnBack(){
            SoundController.StopAll(0.3f);
			SoundController.PlaySE(Model.SE.Tap);
            SceneLoader.LoadScene(Model.GameScenes.Title);
        }
    }
}