using System.Collections.Generic;
using UnityEngine;

namespace Game.Tiles.Graph {
	public class TileGraphNode: MonoBehaviour {
		private List<TileGraphNode> _neighbors = new List<TileGraphNode>();
		private Tile _tile;

		public IReadOnlyCollection<TileGraphNode> Neighbors => _neighbors;
		public Tile Tile => _tile;

		public void SetTile(Tile tile) {
			_tile = tile;
		}

		public void AddNeighbor(TileGraphNode node) {
			if (!_neighbors.Contains(node)) {
				_neighbors.Add(node);
			}
		}
		public void ClearNeighbors() => _neighbors.Clear();
	}
}