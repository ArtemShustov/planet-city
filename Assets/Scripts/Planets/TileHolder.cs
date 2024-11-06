using UnityEngine;

namespace Game.Planets {
	public class TileHolder: MonoBehaviour {
		private ITile _tile;
		private Planet _planet;

		public bool IsFree => _tile == null;
		public ITile Tile => _tile;
		public Planet Planet => _planet;

		public void Init(Planet planet) {
			_planet = planet;
		}

		public void Attach(ITile tile) {
			_tile = tile;
			_tile.OnAttach(_planet);
		}
		public void Detach() {
			_tile.OnDetach(_planet);
			_tile = null;
		}

		private void OnDrawGizmos() {
			Gizmos.DrawWireSphere(transform.position, 0.5f);
			Gizmos.DrawLine(transform.position, transform.position + transform.up);
		}
	}
}