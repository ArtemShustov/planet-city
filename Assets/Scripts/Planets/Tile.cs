using UnityEngine;

namespace Game.Planets {
	[RequireComponent(typeof(TileView))]
	public class Tile: MonoBehaviour, ITile {
		public Planet Planet { get; private set; }
		public TileView View { get; private set; }

		protected virtual void Awake() {
			View = GetComponent<TileView>();
		}

		public virtual void OnAttach(Planet planet) { 
			Planet = planet;
		}
		public virtual void OnDetach(Planet planet) { 
			Planet = null;
		}
	}
}