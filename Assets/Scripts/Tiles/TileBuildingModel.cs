using UnityEngine;

namespace Game.Tiles {
	public class TileBuildingModel: MonoBehaviour, ITileBuildingComponent {
		private TileBuilding _building;

		public TileBuilding Root => _building;

		public void SetRoot(TileBuilding root) => _building = root;

		public virtual void OnAttach() { }
		public virtual void OnDetach() { }
	}
}