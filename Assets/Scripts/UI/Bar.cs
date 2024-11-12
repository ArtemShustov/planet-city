using UnityEngine;
using UnityEngine.UI;

namespace Game.UI {
	public class Bar: MonoBehaviour {
		[SerializeField] private Image _filler;

		public void SetFill(float value) {
			_filler.fillAmount = Mathf.Clamp01(value);
		}
	}
}