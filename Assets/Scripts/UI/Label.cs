using TMPro;
using UnityEngine;

namespace Game.UI {
	public class Label: MonoBehaviour {
		[SerializeField] private TMP_Text _label;
		[SerializeField] private string _pattern = "{0}";

		public void UpdateLabel(params object[] args) {
			_label.text = string.Format(_pattern, args);
		}
	}
}