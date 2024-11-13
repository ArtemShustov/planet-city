using Game.Tiles.Graph;
using UnityEngine;

namespace Game.Tiles {
	[RequireComponent(typeof(TileGraphNode))]
	public class Tile: MonoBehaviour {
		[SerializeField] private TileGraphNode _node;
		[SerializeField] private int _id = -1;
		private TileBuilding _building;
		private Planet _planet;
		private TileResources _resources = new TileResources();

		public int Id => _id;
		public TileGraphNode Node => _node;
		public TileBuilding Building => _building;
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

		public void OnAttach(TileBuilding building) {
			_building = building;
		}
		public void OnDetach() {
			_building = null;
		}
    }
}