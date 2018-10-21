using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using BehaviourMachine;

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
            GameUIManager.UI.StartTimeline();
        }
        public override void OnClick(){}
		public override void OnBack(){}
    }
}