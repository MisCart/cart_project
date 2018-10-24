using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace GameUI
{
	public class CharacterImage : MonoBehaviour
	{
		[SerializeField] Sprite[] images;

        public Sprite[] Images { get { return images; } }
        public void SetActive(bool value){
            gameObject.SetActive(value);
        }
	}
}
