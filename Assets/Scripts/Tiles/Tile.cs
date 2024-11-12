using Game.Tiles.Graph;
using UnityEngine;

namespace Game.Tiles {
	[RequireComponent(typeof(TileGraphNode))]
	public class Tile: MonoBehaviour, ITile {
		private TileGraphNode _node;
		private ITileBuilding _building;
		private Planet _planet;
		private TileResources _resources = new TileResources();

		public TileGraphNode Node => _node;
		public ITileBuilding Building => _building;
		public Planet Planet => _planet;
		public TileResources Resources => _resources;

		private void Awake() {
			_node = GetComponent<TileGraphNode>();
			_node.SetTile(this);
		}

		public void SetPlanet(Planet planet) {
			_planet = planet;
		}

		public void OnAttach(ITileBuilding building) {
			_building = building;
		}
		public void OnDetach(ITileBuilding building) {
			_building = null;
		}
    }
}