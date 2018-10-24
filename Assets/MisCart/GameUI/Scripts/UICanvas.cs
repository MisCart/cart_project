using System.Collections;
using System;
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
        [SerializeField] Text rank;
        [SerializeField] Text finishTime;
        [SerializeField] GameObject resultBox;
        [SerializeField] CharacterImage misChan;
        [SerializeField] PlayableDirector director;
        [SerializeField] GameObject cover;

		Action onClick;
		Action onBack;

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
        public Text Rank { get { return rank; } }
        public Text Time { get { return finishTime; } }
        public GameObject ResultBox { get { return resultBox; } }
        public CharacterImage MisChan { get { return misChan; } }
        public GameObject Cover { get { return cover; } }

        public void StartTimeline(){
            director.Play();
        }

        public void OnClick()
		{
			if (onClick != null){
				onClick();
			}
		}

		public void OnBack()
		{
			if (onBack != null){
				onBack();
			}
		}

		/// <summary>
		/// クリックしたときのの処理を設置
		/// </summary>
		public void SetOnClick(Action action=null){
			onClick = action;
		}

		/// <summary>
		/// 戻るボタンの処理を設置
		/// </summary>
		public void SetOnBack(Action action=null){
			onBack = action;
		}
	}
}
