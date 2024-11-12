using Game.Services;
using UnityEngine;

namespace Game.TileRegistires {
	[CreateAssetMenu(menuName = "Services/TileRegisty")]
	public class TileRegistryService: GameService {
		[SerializeField] private TileRegistyItem[] _tiles = new TileRegistyItem[0];
		
		public override void Init(GameServices services) { }

		public void SetTiles(TileRegistyItem[] tiles) {
			_tiles = tiles;
		}
	}
}