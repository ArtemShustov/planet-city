using UnityEngine;

namespace Game.Planets.TileResources {
	public class Energy: ITileResource {
		private int _value;

		public int Value => _value;

		public void Add(int value) {
			_value += value;
		}
		public void Remove(int value) {
			_value -= value;
		}

		public static void AddFor(TileHolder tile, int value) {
			tile.GetOrCreateResource<Energy>(() => new Energy()).Add(value);
		}
		public static void RemoveFor(TileHolder tile, int value) {
			if (tile == null) {
				return;
			}
			tile.GetOrCreateResource<Energy>(() => new Energy()).Remove(value);
		}
	}
}