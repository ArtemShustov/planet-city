using Game.Planets;
using UnityEngine;

namespace Game.Testing {
	public class TestScienceTarget: MonoBehaviour {
		[SerializeField] private int _target;
		[SerializeField] private PlanetResources _resources;

		private void Start() {
			_resources.Science.SetTarget(_target);
		}
	}
}