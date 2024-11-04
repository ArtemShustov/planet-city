using UnityEngine;

namespace Game.Planets {
	[RequireComponent(typeof(Tile))]
	[RequireComponent(typeof(TileView))]
	[SelectionBase]
	public class TileFacade: MonoBehaviour {
		public Tile Tile { get; private set; }
		public TileView View { get; private set; }
		public TileHolder Holder { get; private set; }

		protected virtual void Awake() {
			Tile = GetComponent<Tile>();
			View = GetComponent<TileView>();
		}

		public void AttachTo(TileHolder holder) {
			Holder = holder;
			View.AttachTo(holder);
			holder.Attach(Tile);
		}
	}
}