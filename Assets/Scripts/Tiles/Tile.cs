using Game.Tiles.Graph;
using UnityEngine;

namespace Game.Tiles {
	[RequireComponent(typeof(TileGraphNode))]
	public class Tile: MonoBehaviour, ITile {
		[SerializeField] private TileGraphNode _node;
		[SerializeField] private int _id = -1;
		private ITileBuilding _building;
		private Planet _planet;
		private TileResources _resources = new TileResources();

		public TileGraphNode Node => _node;
		public ITileBuilding Building => _building;
		public Planet Planet => _planet;
		public TileResources Resources => _resources;

		private void Awake() {
			_node.SetTile(this);
		}

		public void SetPlanet(Planet planet) {
			_planet = planet;
		}
		public void SetId(int id) {
			_id = id;
		}

		public void OnAttach(ITileBuilding building) {
			_building = building;
		}
		public void OnDetach(ITileBuilding building) {
			_building = null;
		}
    }
}