using UnityEngine;

namespace Game.Planets {
	[RequireComponent(typeof(TileView))]
	public class Tile: MonoBehaviour, ITile, ITileComponent {
		public Planet Planet { get; private set; }
		public TileFacade Root { get; private set; }

		public virtual void OnAttach(Planet planet) { 
			Planet = planet;
		}
		public virtual void OnDetach(Planet planet) { 
			Planet = null;
		}

		public void SetCompositionRoot(TileFacade root) => Root = root;
	}
}