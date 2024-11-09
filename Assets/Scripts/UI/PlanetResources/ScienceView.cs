using Game.Ticking;
using UnityEngine;

namespace Game.UI.PlanetResources {
	public class ScienceView: Bar, IPlanetResourceView {
		[SerializeField] private Planets.PlanetResources _resources;
		[SerializeField] private TickGroup _tick;

		public void SetResources(Planets.PlanetResources resources) => _resources = resources;

		private void UpdateBar() {
			if (_resources == null) {
				return;
			}
			var value = _resources.Science.Value;
			var target = _resources.Science.Target == 0 ? _resources.Science.Value : _resources.Science.Target;
			if (value == 0 && target == 0) {
				SetFill(1);
				return;
			}
			SetFill(value / target);
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