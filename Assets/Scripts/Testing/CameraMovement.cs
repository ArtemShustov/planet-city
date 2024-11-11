using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Testing {
	public class CameraMovement: MonoBehaviour {
		[SerializeField] private float _speed = 5;
		[SerializeField] private InputAction _input;
		[SerializeField] private InputAction _reset;

		private void LateUpdate() {
			var input = Vector2.ClampMagnitude(_input.ReadValue<Vector2>(), 1);
			var movement = new Vector3(input.x, 0, input.y) * _speed;
			transform.position += movement * Time.deltaTime;
		}

		private void ResetPosition(InputAction.CallbackContext obj) {
			transform.position = Vector3.zero;
		}

		private void OnEnable() {
			_reset.performed += ResetPosition;
			_input.Enable();
			_reset.Enable();
		}
		private void OnDisable() {
			_reset.performed -= ResetPosition;
			_input.Disable();
			_reset.Disable();
		}
	}
}