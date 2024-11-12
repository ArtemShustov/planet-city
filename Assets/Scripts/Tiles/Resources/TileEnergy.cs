namespace Game.Tiles.Resources {
	public class TileEnergy: ITileResource {
		private int _value;

		public int Value => _value;

		public TileEnergy(int value) {
			_value = value;
		}

		public void Add(int value) {
			_value += value;
		}
		public void Remove(int value) {
			_value -= value;
		}

		public static void AddFor(ITile tile, int value) {
			if (tile.Resources.TryGet<TileEnergy>(out var resource)) {
				resource.Add(value);
			} else {
				var energy = new TileEnergy(value);
				tile.Resources.Add(energy);
			}
		}
		public static void RemoveFor(ITile tile, int value) {
			if (tile.Resources.TryGet<TileEnergy>(out var resource)) {
				resource.Remove(value);
				if (resource.Value <= 0) {
					tile.Resources.Remove<TileEnergy>();
				}
			}
		}
	}
}