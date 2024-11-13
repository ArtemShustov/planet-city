using Game.Tiles.Graph;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Tiles {
	public class Planet: MonoBehaviour {
		[SerializeField] private TileGraph _graph;
		private PlanetResourcesContainer _resources = new();
		private List<Tile> _tiles = new();

		public TileGraph Graph => _graph;
		public PlanetResourcesContainer Resources => _resources;
		public IReadOnlyList<Tile> Tiles => _tiles;

		private void Awake() {
			GetAllTiles();
			_graph.CreateNew(_tiles.Select(t => t.Node).ToList());
			Debug.Log($"Planet with '{_tiles.Count}' tiles");
		}
		private void GetAllTiles() {
			_tiles = GetComponentsInChildren<Tile>().ToList();
			_tiles.ForEach(t => t.SetPlanet(this));
		}

		public void AttachBuilding(Tile tile, TileBuilding building) {
			tile.OnAttach(building);
			building.OnAttach(this, tile);
		}
		public TileBuilding DetachBuilding(Tile tile) {
			var building = tile.Building;
			building?.OnDetach();
			tile.OnDetach();
			return building;
		}
		public TileBuilding ReplaceBuilding(Tile tile, TileBuilding building) {
			var oldBuilding = DetachBuilding(tile);
			AttachBuilding(tile, building);
			return oldBuilding;
		}

		public void ClearResources() => _resources = new PlanetResourcesContainer();
	}
}