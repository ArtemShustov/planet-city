using UnityEngine;

namespace Game.Planets.Tiles {
	public class FarmTile: Tile {
		[SerializeField] private int _count;

		public override void OnAttach(Planet planet) {
			base.OnAttach(planet);
			Planet.Resources.Food.Add(_count);
		}
		public override void OnDetach(Planet planet) {
			Planet.Resources.Food.Remove(_count);
			base.OnDetach(planet);
		}
	}
}