using Game.Graph;
using UnityEngine;

namespace Game.Planets {
	[RequireComponent(typeof(Tile))]
	[RequireComponent(typeof(TileView))]
	[RequireComponent(typeof(TileGraphNode))]
	[SelectionBase]
	public class TileFacade: MonoBehaviour {
		public Tile Tile { get; private set; }
		public TileView View { get; private set; }
		public TileGraphNode Node { get; private set; }
		public TileHolder Holder { get; private set; }

		protected virtual void Awake() {
			Tile = GetComponent<Tile>();
			Tile.SetCompositionRoot(this);
			View = GetComponent<TileView>();
			View.SetCompositionRoot(this);
			Node = GetComponent<TileGraphNode>();
			Node.SetCompositionRoot(this);
		}

		public void AttachTo(TileHolder holder) {
			Holder = holder;
			View.AttachTo(holder);
			holder.Attach(Tile);
		}
		public void Detach() {
			Holder.Detach();
			Holder = null;
		}
	}
}