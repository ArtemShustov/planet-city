using System;
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
				if (node == root) {
					continue;
				}
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

			node.ClearNeighbors();
			_nodes.Remove(node);
			_nodes.Add(with);
			
			toUpdate.ForEach(n => CreateNeighborsFor(n));
		}

		public void ForeachBFS(TileGraphNode start, int depth, Action<TileGraphNode> action) {
			if (depth <= 0) {
				return;
			}

			var visited = new HashSet<TileGraphNode>();
			var toVisit = new Queue<(TileGraphNode node, int currentDepth)>();
			toVisit.Enqueue((start, 0));
			visited.Add(start);

			while (toVisit.Count > 0) {
				var (node, currentDepth) = toVisit.Dequeue();
				if (currentDepth >= depth) {
					break;
				}

				foreach (var neighbor in node.Neighbors) {
					if (!visited.Contains(neighbor)) {
						toVisit.Enqueue((neighbor, currentDepth + 1));
						visited.Add(neighbor);
					}
				}
				// Debug.Log($"BFS visit: {node.name}. Neighbors: {node.Neighbors.Count}. Depth: {currentDepth}");
				action.Invoke(node);
			}
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