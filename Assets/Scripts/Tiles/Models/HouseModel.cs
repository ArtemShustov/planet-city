using UnityEngine;

namespace Game.Tiles.Models {
	public class HouseModel: TickableModel {
		[SerializeField] private int _max;

		private PlanetResourcesContainer _resources;
		private int _current;

		private void SetCurrent(int value) {
			if (_resources == null) {
				return;
			}
			if (_current != 0) {
				_resources.Population.RemoveCount(_current);
			}
			_current = value;
			_resources.Population.AddCount(_current);
		}

		public override void OnTick() {
			var count = Mathf.RoundToInt(_max * _resources.FoodFactor);
			if (_current != count) {
				SetCurrent(count);
			}
		}
		public override void OnAttach() {
			base.OnAttach();
			_resources = Root.Tile.Planet.Resources;
			_resources.Population.AddMax(_max);
		}
		public override void OnDetach() {
			_resources.Population.RemoveMax(_max);
			_resources = null;
			base.OnDetach();
		}
	}
}