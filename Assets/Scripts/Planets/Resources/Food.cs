using UnityEngine;

namespace Game.Planets.Resources {
	public class Food {
		private int _value;

		public int Value => _value;

		public void Add(int value) {
			_value += value;
		}
		public void Remove(int value) {
			_value -= value;
		}
	}
}