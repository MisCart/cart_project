using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviourMachine;
using MisCart;

namespace Title
{
	[AddComponentMenu("CartSelectState")]
	public class CartSelectState : TitleStateBehaviour
	{
		void Start ()
		{
		}

        public override void OnClick(){}
		public override void OnBack(){}

        void OnDisable() {
        }
	}
}
