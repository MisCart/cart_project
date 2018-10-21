using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace GameUI
{
	public class UICanvas : MonoBehaviour
	{
		[SerializeField] TextMeshProUGUI countDown;
        [SerializeField] GameObject countDownObject;
        bool isCountDown = true;
        bool isRunning = false;

        public string CountDownText
        {
            get
            {
                return countDown.text;
            }

            set
            {
                countDown.text = value;
            }
        }

        public GameObject CountDownObject{ get { return countDownObject; } }
	}
}
