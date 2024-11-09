using UnityEngine;

namespace Game.Planets.Tiles {
	public class FactoryTile: TickableTile {
		[SerializeField] private float _maxThrottle = 1;
		[SerializeField] private int _usage;
		[SerializeField] private int _power;

		private int _currentPower;

		protected override void OnTick() {
			var factor = Planet.Resources.Population.Count == 0 ? 0 : Mathf.Clamp01(1 - (Planet.Resources.EfficiencyThrottle / _maxThrottle));
			var power = Mathf.RoundToInt(_power * factor);
			if (_currentPower != power) {
				Planet.Resources.FactoryPower.Remove(_currentPower);
				_currentPower = power;
				Planet.Resources.FactoryPower.Add(_currentPower);
			}
		}

		public override void OnAttach(Planet planet) {
			base.OnAttach(planet);
			Planet.Resources.Population.AddUsed(_usage);
		}
		public override void OnDetach(Planet planet) {
			Planet.Resources.Population.RemoveUsed(_usage);
			if (_currentPower != 0) {
				Planet.Resources.FactoryPower.Remove(_currentPower);
			}
			base.OnDetach(planet);
		}
	}
}