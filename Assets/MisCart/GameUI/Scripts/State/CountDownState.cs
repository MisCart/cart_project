using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using BehaviourMachine;

namespace GameUI
{
    [AddComponentMenu("GameUI/CountDownState")]
    public class CountDownState : GameUIStateBehaviour
    {
        public override void OnClick(){}
		public override void OnBack(){}

        void Start ()
        {
            GameUIManager.UI.SetOnClick(() => OnClick());
            GameUIManager.UI.SetOnBack(() => OnBack());
            StartCoroutine(StartCountDown());
        }

        IEnumerator StartCountDown()
        {
            GameUIManager.UI.CountDownObject.gameObject.SetActive(true);

            var isRunning = Transition.SceneLoader.IsTransitionRunning;
            //蓋絵のアニメーションが終わっていなかったら待機
            while(isRunning)
            {
                isRunning = Transition.SceneLoader.IsTransitionRunning;
                yield return null;
            }

            yield return new WaitForSeconds(1f);
            GameUIManager.UI.CountDownText = "2";
            yield return new WaitForSeconds(1f);
            GameUIManager.UI.CountDownText = "1";
            yield return new WaitForSeconds(1f);
            GameUIManager.UI.CountDownText = "GO!";
            yield return new WaitForSeconds(0.3f);

            GameUIManager.Board.GetBoolVar("IsCounting").Value = false;
            GameUIManager.Board.GetBoolVar("SetCountDown").Value = false;
            SendEvent("FinishCountDown");
            GameUIManager.UI.CountDownObject.gameObject.SetActive(false);
        }

    }
}