using UnityEngine;

namespace Game.Planets.Tiles {
	public class LabTile: TickableTile {
		[SerializeField] private int _pointsPerTick = 1;

		protected override void OnTick() {
			Planet.Resources.Science.AddValue(_pointsPerTick);
		}
	}
}