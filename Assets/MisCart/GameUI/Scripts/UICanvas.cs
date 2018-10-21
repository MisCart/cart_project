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
        [SerializeField] Text message;
        [SerializeField] GameObject resultBox;
        [SerializeField] CharacterImage misChan;
        [SerializeField] PlayableDirector director;

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

        public string Message
        {
            get
            {
                return message.text;
            }

            set
            {
                message.text = value;
            }
        }

        public GameObject CountDownObject { get { return countDownObject; } }
        public GameObject MessageBox { get { return messageBox; } }

        public GameObject ResultBox { get { return resultBox; } }
        public CharacterImage MisChan { get { return misChan; } }

        public void StartTimeline(){
            director.Play();
        }
	}
}
