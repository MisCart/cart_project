using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Transition
{
	public class UICanvas : MonoBehaviour 
	{
        [SerializeField] Fade fade;
		public Fade Fade { get { return fade; } }
	}
}