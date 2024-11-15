using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;

namespace Game {
	public class OrbitCamera: MonoBehaviour {
		[SerializeField] private Transform _target;
		[SerializeField] private float _distance = 10f;
		[SerializeField] private float _rotationSpeed = 5f;
		private float _currentX;
		private float _currentY;
		private bool _moving;

		private void Start() {
			MoveCamera();
		}
		private void Update() {
			if (Input.GetMouseButtonDown(0) && !IsMouseOverUI()) {
				_moving = true;
			}
			if (_moving && Input.GetMouseButtonUp(0)) {
				_moving = false;
			}
		}
		private void LateUpdate() {
			if (_moving) {
				MoveCamera();
			}
		}
		private void MoveCamera() {
			_currentX += Input.GetAxis("Mouse X") * _rotationSpeed;
			_currentY = Mathf.Clamp(_currentY - Input.GetAxis("Mouse Y") * _rotationSpeed, -80, 80);
			var rotation = Quaternion.Euler(_currentY, _currentX, 0);
			transform.position = _target.position + rotation * new Vector3(0, 0, -_distance);
			transform.LookAt(_target);
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