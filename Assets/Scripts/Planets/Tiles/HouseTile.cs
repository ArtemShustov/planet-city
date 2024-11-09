using UnityEngine;

namespace Game.Planets.Tiles {
	public class HouseTile: TickableTile {
		[SerializeField] private int _moneyPerCount;
		[SerializeField] private int _count;

		private int _currentCount;

		protected override void OnTick() { 
			var count = Mathf.RoundToInt(_count * Planet.Resources.FoodFactor);
			if (_currentCount != count) {
				Planet.Resources.Population.RemoveCount(_currentCount);
				_currentCount = count;
				Planet.Resources.Population.AddCount(_currentCount);
			}
			var tax = _currentCount * _moneyPerCount;
			if (tax != 0) {
				Planet.Resources.Money.Add(tax);
			}
		}

		public override void OnAttach(Planet planet) {
			base.OnAttach(planet);
			Planet.Resources.Population.AddMax(_count);
		}
		public override void OnDetach(Planet planet) {
			Planet.Resources.Population.RemoveMax(_count);
			if (_currentCount != 0) {
				Planet.Resources.Population.RemoveCount(_currentCount);
			}
			base.OnDetach(planet);
		}
	}
}