using Game.Ticking;
using Game.Utils;
using UnityEngine;

namespace Game.Testing {
	public class TestTickable: MonoBehaviour {
		[HideInPlayMode]
		[SerializeField] private TickGroup _tickGroup;

		private void OnTick() {
			Debug.Log("Test tick");
		}

		private void OnEnable() {
			_tickGroup.Tick += OnTick;
		}
		private void OnDisable() {
			_tickGroup.Tick -= OnTick;
		}
	}
}