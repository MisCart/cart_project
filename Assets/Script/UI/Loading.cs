using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Title.UI
{
	public class Loading : MonoBehaviour
	{
			public Text Text;
	
			public void SetActive(bool value)
			{
				gameObject.SetActive(value);
			}
	}
}