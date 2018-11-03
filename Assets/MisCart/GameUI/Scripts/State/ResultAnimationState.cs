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

            int minute = (int)GameData.FinishTime / 60;
            int second = (int)GameData.FinishTime % 60;

            //01:04みたいな表記になるようにする
            if(minute < 10 && second < 10){
                GameUIManager.UI.Time.text = "0"+minute+":0"+second;
            }else if(minute < 10){
                GameUIManager.UI.Time.text = "0"+minute+":"+second;
            }else if(second < 10){
                GameUIManager.UI.Time.text = minute+":0"+second;
            }else{
                GameUIManager.UI.Time.text = minute+":"+second;
            }

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
                    GameUIManager.UI.Message = CharacterMessage.misChanBlueLose;
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
                GameUIManager.UI.RankNum.text = "1";
                GameUIManager.UI.RankText.text = "st";
                GameUIManager.UI.RankNum.color = new Color(0.9f, 0.71f, 0.13f, 1f);
                GameUIManager.UI.RankText.color = new Color(0.9f, 0.71f, 0.13f, 1f);
            } else if(GameData.FinishRank == 2){
                GameUIManager.UI.RankNum.text = "2";
                GameUIManager.UI.RankText.text = "nd";
                GameUIManager.UI.RankNum.color = new Color(0.75f, 0.76f, 0.76f, 1f);
                GameUIManager.UI.RankText.color = new Color(0.75f, 0.76f, 0.76f, 1f);
            } else if(GameData.FinishRank == 3){
                GameUIManager.UI.RankNum.text = "3";
                GameUIManager.UI.RankText.text = "rd";
                GameUIManager.UI.RankNum.color = new Color(0.75f, 0.55f, 0.37f, 1f);
                GameUIManager.UI.RankText.color = new Color(0.75f, 0.55f, 0.37f, 1f);
            } else {
                GameUIManager.UI.RankNum.text = GameData.FinishRank+"";
                GameUIManager.UI.RankText.text = "th";
            }
        }

        void PlaySound(){
            SoundController.StopAll();
            if(GameData.FinishRank <= 3){
                GameUIManager.Sound.PlayWin();
            }else{
                GameUIManager.Sound.PlayLose();
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

            //データを初期化
            GameData.CharacterId = 0;
            GameData.CartId = 0;
            GameData.FinishRank = 0;
            GameData.FinishTime = 0;

            SceneLoader.LoadScene(Model.GameScenes.Title);
        }
    }
}