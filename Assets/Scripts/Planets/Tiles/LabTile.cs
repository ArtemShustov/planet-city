using Game.Planets.TileResources;
using UnityEngine;

namespace Game.Planets.Tiles {
	public class LabTile: TickableTile {
		[SerializeField] private int _requredEnergy = 1;
		[SerializeField] private int _pointsPerTick = 1;

		protected override void OnTick() {
			if (Root.Holder.TryGetResource<Energy>(out var energy) && energy.Value >= _requredEnergy) {
				Planet.Resources.Science.AddValue(_pointsPerTick);
			}
		}
	}
}