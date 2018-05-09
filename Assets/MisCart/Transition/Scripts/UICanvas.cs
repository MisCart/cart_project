using UnityEngine;

namespace Transition
{
	public class UICanvas : MonoBehaviour
	{
        [SerializeField] Fade fade;
        [SerializeField] FadeImage fadeImage;
		public Fade Fade { get { return fade; } }
        public FadeImage FadeImage { get { return fadeImage; } }
	}
}