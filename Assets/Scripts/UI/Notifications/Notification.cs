using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Notifications {
	public class Notification: MonoBehaviour {
		[SerializeField] private float _lifetime = 5;
		[SerializeField] private Image _icon;
		[SerializeField] private TMP_Text _body;

		public void SetContent(Sprite icon, string text) {
			_icon.sprite = icon;
			_body.text = text;
		}
		public void SetContent(string text) {
			_body.text = text;
		}

		private void OnEnable() {
			Destroy(gameObject, _lifetime);
		}
	}
}