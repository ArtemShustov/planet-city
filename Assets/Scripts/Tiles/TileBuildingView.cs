using UnityEngine;

namespace Game.Tiles {
	public class TileBuildingView: MonoBehaviour, ITileBuildingComponent {
		private ITileBuilding _building;

		public ITileBuilding Root => _building;

		public void SetRoot(ITileBuilding root) => _building = root;

		public virtual void OnAttach() { }
		public virtual void OnDetach() { }
	}
}