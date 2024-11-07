using Game.Planets;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Graph {
	[RequireComponent(typeof(TileFacade))]
	public class TileGraphNode: MonoBehaviour, ITileComponent {
		private List<TileGraphNode> _neighbors = new List<TileGraphNode>();
		private TileFacade _root;


		public IReadOnlyList<TileGraphNode> Neighbors => _neighbors;
		public TileFacade Root => _root;

		private void Awake() {
			_root = GetComponent<TileFacade>();
		}

		public void AddNeighbor(TileGraphNode node) {
			if (!_neighbors.Contains(node)) {
				_neighbors.Add(node);
			}
		}
		public void ClearNeighbors() => _neighbors.Clear();

		public void SetCompositionRoot(TileFacade root) => _root = root;
	}
}