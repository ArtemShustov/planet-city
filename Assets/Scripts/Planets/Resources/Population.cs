namespace Game.Planets.Resources {
	public class Population {
		private int _max;
		private int _count;
		private int _used;

		public int Max => _max;
		public int Count => _count;
		public int Used => _used;

		public void AddMax(int max) {
			_max += max;
		}
		public void RemoveMax(int max) {
			_max -= max;
		}
		public void AddCount(int value) {
			_count += value;
		}
		public void RemoveCount(int value) {
			_count -= value;
		}
		public void AddUsed(int value) {
			_used += value;
		}
		public void RemoveUsed(int value) {
			_used -= value;
		}
	}
}