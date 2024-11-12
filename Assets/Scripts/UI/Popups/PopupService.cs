using Game.Services;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.Popups {
	[CreateAssetMenu(menuName = "Services/Popup")]
	public class PopupService: GameService {
		[SerializeField] private PopupWindow _windowPrefab;
		[SerializeField] private GameObject _eventSystemPrefab;

		private PopupWindow _current;

		public override void Init(GameServices services) { }

		public void Show(string label, string body) {
			Debug.Log($"Current: {_current}");
			if (_current != null) {
				Destroy(_current.gameObject);
			}
			var window = Instantiate(_windowPrefab);
			if (FindFirstObjectByType<EventSystem>() == null) {
				Instantiate(_eventSystemPrefab, window.transform);
			}

			window.SetContent(label, body);
			window.CloseButtonClicked += OnCloseButton;
			window.gameObject.SetActive(true);
			
			// DontDestroyOnLoad(window);
			_current = window;
		}
		public void Hide() {
			if (_current != null) {
				Destroy(_current.gameObject);
			}
		}

		public void OnCloseButton() {
			Hide();
		}
	}
}