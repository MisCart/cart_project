using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using TMPro;

namespace GameUI
{
	public class UICanvas : MonoBehaviour
	{
		[SerializeField] TextMeshProUGUI countDown;
        [SerializeField] GameObject countDownObject;
        [SerializeField] GameObject messageBox;
        [SerializeField] GameObject resultBox;
        [SerializeField] GameObject misChan;
        [SerializeField] PlayableDirector director;
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

        public GameObject CountDownObject { get { return countDownObject; } }
        public GameObject MessageBox { get { return messageBox; } }
        public GameObject ResultBox { get { return resultBox; } }
        public GameObject MisChan { get { return misChan; } }

        public void StartTimeline(){
            director.Play();
        }
	}
}
