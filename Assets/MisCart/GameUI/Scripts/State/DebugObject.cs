using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using TMPro;

namespace GameUI
{
	public class DebugObject : MonoBehaviour
	{
        void OnEnable() {
            GameData.CharacterId = 4;
            GameData.rank = 3;
            GameUIManager.StartAnimation();
        }

	}
}
