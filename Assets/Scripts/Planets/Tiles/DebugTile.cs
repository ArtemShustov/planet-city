using UnityEngine;

namespace Game.Planets.Tiles {
	public class DebugTile: Tile {
		private void OnTick() {
			Debug.Log("DebugTile tick");
		}

		public override void OnAttach(Planet planet) {
			base.OnAttach(planet);
			Planet.Tick += OnTick;
		}
		public override void OnDetach(Planet planet) {
			Planet.Tick -= OnTick;
			base.OnDetach(planet);
		}

		private void OnDrawGizmos() {
			if (Root == null || Root.Node.Neighbors.Count == 0) {
				return;
			}
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(transform.position, 1f);
			foreach (var node in Root.Node.Neighbors) {
				Gizmos.DrawLine(transform.position, node.transform.position);
			}
		}
	}
}