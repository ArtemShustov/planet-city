using System;

namespace Game.Planets.Resources {
	public class Science {
		private int _value;
		private int _target;

		public event Action TargetReached;

		public int Value => _value;
		public int Target => _target;

		public void SetTarget(int target, bool clearValue = false) {
			_target = target;
			if (clearValue) {
				_value = 0;
			}
		}
		public void AddValue(int value) {
			_value += value;
			if (_value >= _target) {
				TargetReached?.Invoke();
			}
		}
		public void RemoveValue(int value) {
			_value -= value;
		}
	}
}