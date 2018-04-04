using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Fade : MonoBehaviour
{
	IFade fade;

	float cutoutRange;
	bool isfading = false;

	void Awake ()
	{
		Init ();
		fade.Range = cutoutRange;
	}

	void Init ()
	{
		fade = GetComponent<IFade> ();
	}

	void OnValidate ()
	{
		Init ();
		fade.Range = cutoutRange;
	}

	IEnumerator FadeoutCoroutine (float time, System.Action action)
	{
		isfading = true;
		DOTween.To(
			() => fade.Range,
			cutoutRange => fade.Range = cutoutRange,
			0f,
			time
		).OnComplete(() => isfading = false);

		while(isfading){ yield return null; }
		cutoutRange = 0;
		fade.Range = cutoutRange;

		if (action != null) {
			action ();
		}
	}

	IEnumerator FadeinCoroutine (float time, System.Action action)
	{
		isfading = true;
		DOTween.To(
			() => fade.Range,
			cutoutRange => fade.Range = cutoutRange,
			1f,
			time
		).OnComplete(() => isfading = false);

		while(isfading){ yield return null; }	
		cutoutRange = 1;
		fade.Range = cutoutRange;

		if (action != null) {
			action ();
		}
	}

	public Coroutine FadeOut (float time, System.Action action = null)
	{
		StopAllCoroutines ();
		return StartCoroutine (FadeoutCoroutine (time, action));
	}

	public Coroutine FadeIn (float time, System.Action action = null)
	{
		StopAllCoroutines ();
		return StartCoroutine (FadeinCoroutine (time, action));
	}
}