using Game.Planets;
using UnityEngine;

namespace Game.Testing {
	public class TileBrush: MonoBehaviour {
		[SerializeField] private TileFacadeSelector _selector;
		[SerializeField] private Planet _planet;
		[SerializeField] private TileFacade _prefab;

		private void Paint(TileFacade tile) {
			var newTile = Instantiate(_prefab);
			_planet.Replace(tile, newTile);
			Destroy(tile.gameObject);
		}

		private void OnEnable() {
			_selector.Selected += Paint;
		}
		private void OnDisable() {
			_selector.Selected -= Paint;
		}
	}
}