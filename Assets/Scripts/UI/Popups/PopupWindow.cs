using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Popups {
	public class PopupWindow: MonoBehaviour {
		[SerializeField] private TMP_Text _label;
		[SerializeField] private TMP_Text _body;
		[SerializeField] private Button _closeButton;

		public event Action CloseButtonClicked;

		public void SetContent(string label, string body) {
			_label.text = label;
			_body.text = body;
		}

		private void OnCloneButton() {
			CloseButtonClicked?.Invoke();
		}
		private void OnEnable() {
			_closeButton.onClick.AddListener(OnCloneButton);
		}
		private void OnDisable() {
			_closeButton.onClick.RemoveListener(OnCloneButton);
		}
	}
}