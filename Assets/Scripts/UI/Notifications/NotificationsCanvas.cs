using UnityEngine;

namespace Game.UI.Notifications {
	public class NotificationsCanvas: MonoBehaviour {
		[SerializeField] private RectTransform _root;

		public void Add(Notification notification) {
			notification.transform.SetParent(_root);
		}
	}
}