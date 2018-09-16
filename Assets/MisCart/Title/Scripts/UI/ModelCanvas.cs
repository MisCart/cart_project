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
		[SerializeField] GameObject[] cart;

		public GameObject Character { get { return character; } }
		public GameObject[] Cart { get { return cart; } }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

	}
}
