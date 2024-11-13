using Game.Tiles;
using Game.Tiles.Resources;
using UnityEngine;

namespace Game.Testing {
	public class EnergyInfo: MonoBehaviour {
		[SerializeField] private TileSelector _selector;

		public void OnSelect(Tile tile) {
			if (tile.Resources.TryGet<TileEnergy>(out var energy)) {
				Debug.Log($"Energy: {energy.Value}");
			}
		}

		private void OnEnable() {
			_selector.Selected += OnSelect;
		}
		private void OnDisable() {
			_selector.Selected -= OnSelect;
		}
	}
}