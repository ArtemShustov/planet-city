using System;

namespace Game.Tiles.PlanetResources {
	[Serializable]
	public class Science {
		private int _value;
		private int _target;

		public int Value => _value;
		public int Target => _target;

		public void SetTarget(int target) => _target = target;
		public void Add(int value) => _value += value;
		public void Remove(int value) => _value -= value;
	}
}