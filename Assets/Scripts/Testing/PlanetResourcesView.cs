using Game.Planets;
using UnityEngine;

namespace Game.Testing {
	public class PlanetResourcesView: MonoBehaviour {
		[SerializeField] private int _fontSize = 48;
		[SerializeField] private PlanetResources _resources;

		private GUIStyle _style;

		private void OnGUI() {
			GUILayout.TextField($"Population: u{_resources.Population.Used}/c{_resources.Population.Count}", _style);
			GUILayout.TextField($"Food: v{_resources.Food.Value}", _style);
			GUILayout.TextField($"FactoryPower: v{_resources.FactoryPower.Value}", _style);
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