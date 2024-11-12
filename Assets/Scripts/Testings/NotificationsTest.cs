using Game.Services;
using Game.UI.Notifications;
using UnityEngine;

namespace Game.Testing {
	public class NotificationsTest: MonoBehaviour {
		private void Update() {
			if (Input.GetKeyDown(KeyCode.Keypad1)) {
				GameServices.GetService<NotificationsService>().ShowInfo("Info text");
			}
			if (Input.GetKeyDown(KeyCode.Keypad2)) {
				GameServices.GetService<NotificationsService>().ShowWarning("Warning text");
			}
			if (Input.GetKeyDown(KeyCode.Keypad3)) {
				GameServices.GetService<NotificationsService>().ShowError("Error text");
			}
		}
	}
}