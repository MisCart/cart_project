using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(RawImage))]
[RequireComponent (typeof(Mask))]
public class FadeUI : MonoBehaviour, IFade
{

	[SerializeField, Range (0, 1)]
	private float cutoutRange;

	public float Range {
		get {
			return cutoutRange;
		}
		set {
			cutoutRange = value;
			UpdateMaskCutout (cutoutRange);
		}
	}

	[SerializeField] Material mat = null;
	[SerializeField] RenderTexture rt = null;

	[SerializeField] Texture texture = null;

	private void UpdateMaskCutout (float range)
	{
		mat.SetFloat ("_Range", range);

		UnityEngine.Graphics.Blit (texture, rt, mat);

		var mask = GetComponent<Mask> ();
		mask.enabled = false;
		mask.enabled = true;
	}
}
