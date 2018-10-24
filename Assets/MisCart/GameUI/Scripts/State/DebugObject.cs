using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using TMPro;
using Transition;
using Model;

namespace GameUI
{
	public class DebugObject : MonoBehaviour
	{
        void OnEnable() {
            GameData.CharacterId = 4;
            GameData.FinishRank = 5;
            GameData.FinishTime = 145f;
        }
	}
}
