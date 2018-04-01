using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Transition;

namespace Title.UI
{
	public class ChangeScene : MonoBehaviour 
	{
		public Model.GameScenes scene;

		public void SwitchScene()
		{
			SceneLoader.LoadScene(scene, new[] { Model.GameScenes.GameUI });
		}
	}
}
