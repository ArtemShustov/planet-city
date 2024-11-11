using Game.Planets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Testing {
	public class PlanetResourcesView: MonoBehaviour {
		[SerializeField] private int _fontSize = 48;
		[SerializeField] private PlanetResources _resources;
		[SerializeField] private InputAction _toggle;

		private bool _active;
		private GUIStyle _style;

		private void Awake() {
			_style = new GUIStyle();
			_style.fontSize = _fontSize;
		}

		private void Toggle(InputAction.CallbackContext obj) {
			_active = !_active;
		}

		private void OnEnable() {
			_toggle.Enable();
			_toggle.performed += Toggle;
		}
		private void OnDisable() {
			_toggle.Disable();
			_toggle.performed -= Toggle;
		}

		private void OnGUI() {
			if (!_active) {
				return;
			}
			GUILayout.TextField($"Population: u{_resources.Population.Used}/c{_resources.Population.Count}", _style);
			GUILayout.TextField($"Food: v{_resources.Food.Value}", _style);
			GUILayout.TextField($"FactoryPower: v{_resources.FactoryPower.Value}", _style);
			GUILayout.TextField($"Science: v{_resources.Science.Value}/t{_resources.Science.Target}", _style);
			GUILayout.TextField($"Food factor: {_resources.FoodFactor}", _style);
			GUILayout.TextField($"Efficiency throttle: {_resources.EfficiencyThrottle}", _style);
		}
		private void OnValidate() {
			if (Application.isPlaying) {
				_style = new GUIStyle();
				_style.fontSize = _fontSize;
			}
		}
	}
}