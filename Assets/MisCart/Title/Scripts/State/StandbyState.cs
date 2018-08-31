using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using BehaviourMachine;

namespace Title
{
    [AddComponentMenu("MisCart/Title/StandbyState")]
    public class StandbyState : StateBehaviour
    {

        /// <summary>
        /// UIを一度全て非表示にさせる
        /// </summary>
        void Start ()
        {
    		TitleManager.UI.SplashScreen.SetActive(false);
    		TitleManager.UI.Start.SetActive(false);
    		TitleManager.Front.Camera.gameObject.SetActive(false);
    		TitleManager.Front.SetActive(false);
            SendEvent("EndAction");
        }

        void Update () {

        }
    }
}