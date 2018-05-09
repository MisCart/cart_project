using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Title.UI
{
	public class FrontCanvas : MonoBehaviour
	{
        [SerializeField] StageSelect stageSelect;
        [SerializeField] GameObject coverImage;
        [SerializeField] Camera camera;
        public StageSelect StageSelect { get { return stageSelect; } }
        public GameObject Cover { get { return coverImage; } }
        public Camera Camera { get { return camera; } }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
	}
}