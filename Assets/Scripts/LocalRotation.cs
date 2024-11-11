using UnityEngine;

namespace Game {
	public class LocalRotation: MonoBehaviour {
		[SerializeField] private float _speed;
		[SerializeField] private Vector3 _axis;

		private void Update() {
			transform.localEulerAngles += Time.deltaTime * _speed * _axis;
		}
	}
}