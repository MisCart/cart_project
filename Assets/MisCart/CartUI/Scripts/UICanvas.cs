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
        bool isCountDown = true;

        public bool IsCountDown { get { return isCountDown; } }

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

        void Start()
        {
            StartCoroutine(StartCountDown());
        }

        IEnumerator StartCountDown()
        {

            isCountDown = true;
            countDown.gameObject.SetActive(true);

            yield return new WaitForSeconds(1f);
            CountDownText = "2";
            yield return new WaitForSeconds(1f);
            CountDownText = "1";
            yield return new WaitForSeconds(1f);
            CountDownText = "GO!";
            isCountDown = false;
            yield return new WaitForSeconds(0.3f);

            countDown.gameObject.SetActive(false);
        }
	}
}
