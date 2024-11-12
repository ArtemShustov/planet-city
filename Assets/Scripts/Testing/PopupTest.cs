using Game.Services;
using Game.UI.Popups;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Testing {
	public class PopupTest: MonoBehaviour {
		private bool _isFirstScene;

		private void Update() {
			if (Input.GetKeyDown(KeyCode.C)) {
				_isFirstScene = !_isFirstScene;
				SceneManager.LoadScene(_isFirstScene ? 0 : 1);
				return;
			}
			if (Input.GetKeyDown(KeyCode.P)) {
				GameServices.GetService<PopupService>()?.Show("Test label", "test body text. <#FF0000>red color</color>");
			}
		}
	}
}