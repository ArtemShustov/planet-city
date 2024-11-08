namespace Game.Planets.Resources {
	public class Money {
		private int _value;

		public int Value => _value;

		public void Add(int amoun) {
			_value += amoun;
		}
		public void Take(int amount) {
			_value -= amount;
		}
		public bool CanTake(int amount) {
			return _value >= amount;
		}
	}
}