using System;

namespace Game.Tiles.PlanetResources {
	[Serializable]
	public class Money {
		private int _value;

		public int Value => _value;

		public void Add(int value) {
			_value += value;
		}
		public void Take(int value) {
			_value -= value;
		}
	}
}