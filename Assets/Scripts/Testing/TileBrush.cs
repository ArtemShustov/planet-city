using Game.Planets;
using UnityEngine;

namespace Game.Testing {
	public class TileBrush: MonoBehaviour {
		[SerializeField] private TileFacadeSelector _selector;
		[SerializeField] private TileFacade _prefab;

		private void Paint(TileFacade tile) {
			var holder = tile.Holder;
			tile.Tile.OnDetach(tile.Tile.Planet);
			Destroy(tile.gameObject);

			var newTile = Instantiate(_prefab);
			newTile.AttachTo(holder);
		}

		private void OnEnable() {
			_selector.Selected += Paint;
		}
		private void OnDisable() {
			_selector.Selected -= Paint;
		}
	}
}