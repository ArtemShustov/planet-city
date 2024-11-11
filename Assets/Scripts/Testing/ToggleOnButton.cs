using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Testing {
	public class ToggleOnButton: MonoBehaviour {
		[SerializeField] private InputAction _input;
		[SerializeField] private List<GameObject> _list;

		private bool _enabled;

		private void Toggle(InputAction.CallbackContext context) {
			_enabled = !_enabled;
			_list.ForEach(o => o.SetActive(_enabled));
		}

		private void OnEnable() {
			_input.Enable();
			_input.performed += Toggle;
		}
		private void OnDisable() {
			_input.Disable();
			_input.performed -= Toggle;
		}
	}
}
