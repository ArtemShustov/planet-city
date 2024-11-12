using Game.Tiles.Resources;
using UnityEngine;

namespace Game.Tiles.Models {
	public class LabModel: TickableModel {
		[SerializeField] private int _points;
		[SerializeField] private int _requiredPower;

		private PlanetResourcesContainer _resources;
		private TileEnergy _energy;

		public override void OnTick() {
			if (Root.Tile == null) {
				return;
			}
			if (_energy == null && Root.Tile.Resources.TryGet<TileEnergy>(out _energy) == false) {
				return;
			}
			if (_energy.Value >= _requiredPower) {
				_resources.Science.Add(_points);
			}
		}
		public override void OnAttach() {
			base.OnAttach();
			_resources = Root.Tile.Planet.Resources;
		}
		public override void OnDetach() {
			_resources = null;
			base.OnDetach();
		}
	}
}