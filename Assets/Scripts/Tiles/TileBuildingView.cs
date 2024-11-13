using UnityEngine;

namespace Game.Tiles {
	public class TileBuildingView: MonoBehaviour, ITileBuildingComponent {
		private TileBuilding _building;

		public TileBuilding Root => _building;

		public void SetRoot(TileBuilding root) => _building = root;

		public virtual void OnAttach() {
			transform.parent = Root.Tile.transform;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
		}
		public virtual void OnDetach() { }
	}
}