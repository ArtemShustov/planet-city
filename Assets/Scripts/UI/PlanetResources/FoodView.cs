using Game.Ticking;
using UnityEngine;

namespace Game.UI.PlanetResources {
	public class FoodView: Bar, IPlanetResourceView {
		[SerializeField] private Planets.PlanetResources _resources;
		[SerializeField] private TickGroup _tick;

		public void SetResources(Planets.PlanetResources resources) => _resources = resources;

		private void UpdateBar() {
			if (_resources == null) {
				return;
			}
			SetFill(_resources.FoodFactor);
		}

		private void OnEnable() {
			_tick.Tick += UpdateBar;
			UpdateBar();
		}
		private void OnDisable() {
			_tick.Tick -= UpdateBar;
		}
	}
}