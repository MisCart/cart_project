using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MisCart;

namespace Title.UI
{
	public class ModelCanvas : MonoBehaviour
	{
		[SerializeField] GameObject character;

		public GameObject Character { get { return character; } }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

	}
}
