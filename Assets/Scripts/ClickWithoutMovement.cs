using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace Game {
	public class ClickWithoutMovement: MonoBehaviour {
		[SerializeField] private float _maxCursorMovementThreshold = 10;
		[SerializeField] private InputAction _clickAction;

		private Vector2 _initialMousePosition;
		private bool _isMouseHeld;

		public event Action Performed;

		private void OnDown(InputAction.CallbackContext context) {
			_initialMousePosition = Pointer.current.position.ReadValue();
			_isMouseHeld = true;
		}
		private void OnUp(InputAction.CallbackContext context) {
			if (_isMouseHeld) {
				Vector2 finalMousePosition = Pointer.current.position.ReadValue();
				if (Vector2.Distance(_initialMousePosition, finalMousePosition) < _maxCursorMovementThreshold) {
					if (IsMouseOverUI() == false) {
						Performed?.Invoke();
					}
				}
				_isMouseHeld = false;
			}
		}

		private void OnEnable() {
			_clickAction.Enable();
			_clickAction.started += OnDown;
			_clickAction.canceled += OnUp;
		}
		private void OnDisable() {
			_clickAction.started -= OnDown;
			_clickAction.canceled -= OnUp;
			_clickAction.Disable();
		}

		private bool IsMouseOverUI() {
			if (EventSystem.current == null) {
				return false;
			}
			RaycastResult lastRaycastResult = ((InputSystemUIInputModule)EventSystem.current.currentInputModule).GetLastRaycastResult(Mouse.current.deviceId);
			const int uiLayer = 5;
			return lastRaycastResult.gameObject != null && lastRaycastResult.gameObject.layer == uiLayer;
		}
	}
}