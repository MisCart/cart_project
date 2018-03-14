using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Title.UI
{
	public class SplashScreen : MonoBehaviour
	{
	    [SerializeField] Image image;
	    [SerializeField] Image miswLogo;
		[SerializeField] GameObject misw;

		bool isShowLogo = false;
		bool isScreened = false;

		public bool IsScreen { get { return isScreened; } }
	
		public void SetActive(bool value)
		{
			gameObject.SetActive(value);
		}


		public IEnumerator Screen()
		{
			misw.SetActive(true);

			//MISWのロゴをフェードイン
			DOTween.ToAlpha(
				() => miswLogo.color,
				Color => miswLogo.color = Color,
				1f,
				2f
			).OnComplete(() => isShowLogo = true);

			while(!isShowLogo) { yield return null; }

			//MisWのロゴをフェードアウト
			DOTween.ToAlpha(
				() => miswLogo.color,
				Color => miswLogo.color = Color,
				0f,
				2f
			).OnComplete(() => isShowLogo = false);
			
			while(isShowLogo) { yield return null; }

			misw.SetActive(false);

			//スプラッシュスクリーンをフェードアウト
			DOTween.ToAlpha(
				() => image.color,
				color => image.color = color,
				0f,
				3f
			).OnComplete(() => Reset());

		}
		void Reset()
		{
			isScreened = true;
			gameObject.SetActive(false);
		}
	}
}