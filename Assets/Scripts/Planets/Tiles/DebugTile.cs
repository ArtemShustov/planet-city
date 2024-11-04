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
	}
}