using Game.Tiles.Graph;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Tiles {
	public class Planet: MonoBehaviour {
		[SerializeField] private TileGraph _graph;
		private List<ITile> _tiles = new();

		public TileGraph Graph => _graph;

		private void Awake() {
			GetAllTiles();
			_graph.CreateNew(_tiles.Select(t => t.Node).ToList());
			Debug.Log($"Planet with '{_tiles.Count}' tiles");
		}
		private void GetAllTiles() {
			_tiles = GetComponentsInChildren<ITile>().ToList();
			_tiles.ForEach(t => t.SetPlanet(this));
		}

		public void Attach(ITile tile, ITileBuilding building) {
			tile.OnAttach(building);
			building.OnAttach(this, tile);
		}
		public void Replace(ITile tile, ITileBuilding building) {
			tile.Building.OnDetach(this, tile);
			tile.OnDetach(tile.Building);

			Attach(tile, building);
		}
	}
}