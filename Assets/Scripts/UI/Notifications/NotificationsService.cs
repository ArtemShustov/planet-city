using Game.Services;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.Notifications {
	[CreateAssetMenu(menuName = "Services/UI Notifications")]
	public class NotificationsService: GameService {
		[SerializeField] private Notification _infoPrefab;
		[SerializeField] private Notification _warningPrefab;
		[SerializeField] private Notification _errorPrefab;
		[Space]
		[SerializeField] private NotificationsCanvas _notificationsPrafab;
		[SerializeField] private GameObject _eventSystemPrefab;
		
		private NotificationsCanvas _current;

		public override void Init(GameServices services) { }

		public NotificationsCanvas GetCanvas() {
			if (_current != null) {
				return _current;
			}
			var instance = Instantiate(_notificationsPrafab);
			if (FindFirstObjectByType<EventSystem>() == null) {
				Instantiate(_eventSystemPrefab, instance.transform);
			}
			_current = instance;
			return instance;
		}
		public Notification ShowFromPrefab(Notification prefab, string text) {
			var instance = Instantiate(prefab);
			instance.SetContent(text);
			GetCanvas().Add(instance);
			return instance;
		}
		public Notification ShowInfo(string message) => ShowFromPrefab(_infoPrefab, message);
		public Notification ShowWarning(string message) => ShowFromPrefab(_warningPrefab, message);
		public Notification ShowError(string message) => ShowFromPrefab(_errorPrefab, message);
	}
}