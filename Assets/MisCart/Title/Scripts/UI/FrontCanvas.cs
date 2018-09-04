using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Title.UI
{
	public class FrontCanvas : MonoBehaviour
	{
        [SerializeField] GameObject coverImage;
        [SerializeField] Camera camera;
        public Camera Camera { get { return camera; } }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
	}
}