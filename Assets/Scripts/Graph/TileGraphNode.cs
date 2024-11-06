using Game.Planets;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Graph {
	[RequireComponent(typeof(Tile))]
	public class TileGraphNode: MonoBehaviour {
		private Tile _tile;
		private List<TileGraphNode> _neighbors = new List<TileGraphNode>();
		
		public Tile Tile => _tile;
		public IReadOnlyList<TileGraphNode> Neighbors => _neighbors;

		private void Awake() {
			_tile = GetComponent<Tile>();
		}

		public void AddNeighbor(TileGraphNode node) {
			if (!_neighbors.Contains(node)) {
				_neighbors.Add(node);
			}
		}
		public void ClearNeighbors() => _neighbors.Clear();
	}
}