using Game.Services;
using System.Linq;
using UnityEngine;

namespace Game.TileRegistires {
	[CreateAssetMenu(menuName = "Services/Building registry")]
	public class TileBuildingRegistryService: GameService {
		[SerializeField] private TileBuildingRegistryItem[] _buildings = new TileBuildingRegistryItem[0];
		
		public override void Init(GameServices services) { }

		public void SetBuildings(TileBuildingRegistryItem[] buildings) {
			_buildings = buildings;
		}

		public TileBuildingRegistryItem Get(string id) {
			return _buildings.First(i => i.Id == id);
		}
		public bool TryGet(string id, out TileBuildingRegistryItem item) {
			item = _buildings.FirstOrDefault(i => i.Id == id);
			return item != null;
		}
	}
}