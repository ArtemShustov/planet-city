using System;

namespace Game.Tiles.PlanetResources {
	[Serializable]
	public class Population {
		private int _count;
		private int _used;
		private int _max;

		public int Count => _count;
		public int Used => _used;
		public int Max => _max;

		public void AddCount(int count) => _count += count;
		public void RemoveCount(int count) => _count -= count;
		public void AddUsed(int used) => _used += used;
		public void RemoveUsed(int used) => _used -= used;
		public void AddMax(int max) => _max += max;
		public void RemoveMax(int max) => _max -= max;
	}
}