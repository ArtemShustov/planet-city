using UnityEngine;

namespace Game.Testing {
	public class CameraOrbit: MonoBehaviour {
		[SerializeField] private Transform _target;
		[SerializeField] private float _distance = 10f;
		[SerializeField] private float _rotationSpeed = 5f;

		private float _currentX;
		private float _currentY;

		private void Start() {
			MoveCamera();
		}
		private void LateUpdate() {
			if (!Input.GetMouseButton(1)) return;
			MoveCamera();
		}

		private void MoveCamera() {
			_currentX += Input.GetAxis("Mouse X") * _rotationSpeed;
			_currentY = Mathf.Clamp(_currentY - Input.GetAxis("Mouse Y") * _rotationSpeed, -80, 80);
			var rotation = Quaternion.Euler(_currentY, _currentX, 0);
			transform.position = _target.position + rotation * new Vector3(0, 0, -_distance);
			transform.LookAt(_target);
		}
	}
}
