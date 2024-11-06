using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Graph {
	public class TileGraph: MonoBehaviour {
		[SerializeField] private float _distance = 5f;

		private List<TileGraphNode> _nodes = new List<TileGraphNode>();

		public IReadOnlyList<TileGraphNode> Nodes => _nodes;

		public void CreateNew() {
			_nodes = GameObject.FindObjectsByType<TileGraphNode>(FindObjectsSortMode.None).ToList();
			_nodes.ForEach(n => CreateNeighborsFor(n));
		}
		private void CreateNeighborsFor(TileGraphNode root) {
			root.ClearNeighbors();
			foreach (var node in _nodes) {
				if (Vector3.Distance(node.transform.position, root.transform.position) <= _distance) {
					root.AddNeighbor(node);
				}
			}
		}

		public void Replace(TileGraphNode node, TileGraphNode with) {
			if (!_nodes.Contains(node) || _nodes.Contains(with)) {
				return;
			}
			var toUpdate = new List<TileGraphNode>();
			toUpdate.Add(with);
			toUpdate.AddRange(node.Neighbors);
			_nodes.Remove(node);
			_nodes.Add(with);
			toUpdate.ForEach(n => CreateNeighborsFor(n));
		}

		private void OnDrawGizmosSelected() {
			Gizmos.color = Color.white;
			foreach (var node in _nodes) {
				// Gizmos.DrawWireSphere(node.transform.position, _distance);
				Gizmos.DrawSphere(node.transform.position, 0.5f);
				foreach (var neighbor in node.Neighbors) {
					Gizmos.DrawLine(node.transform.position, neighbor.transform.position);
				}
			}
		}
	}
}