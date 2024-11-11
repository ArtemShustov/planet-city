using UnityEngine;

namespace Game.Planets.Tiles {
	public class HouseTile: TickableTile {
		[Min(0)]
		[SerializeField] private int _changeChance = 0;
		[Min(0)]
		[SerializeField] private int _moneyPerCount;
		[Min(0)]
		[SerializeField] private int _count;

		private int _currentCount;

		protected override void OnTick() { 
			var count = Mathf.RoundToInt(_count * Planet.Resources.FoodFactor);
			if (_currentCount != count) {
				var rnd = UnityEngine.Random.Range(0, _changeChance);
				if (rnd == 0) {
					var value = _currentCount + (count > _currentCount ? 1 : -1);
					SetCurrentCount(value);
				}
			}

			var tax = _currentCount * _moneyPerCount;
			if (tax != 0) {
				Planet.Resources.Money.Add(tax);
			}
		}
		private void SetCurrentCount(int value) {
			Planet.Resources.Population.RemoveCount(_currentCount);
			_currentCount = value;
			Planet.Resources.Population.AddCount(_currentCount);
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