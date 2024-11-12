using Game.Services;
using UnityEngine;

namespace Game.TileRegistires {
	[CreateAssetMenu(menuName = "Services/Building registry")]
	public class TileBuildingRegistryService: GameService {
		[SerializeField] private TileBuildingRegistryItem[] _buildings = new TileBuildingRegistryItem[0];
		
		public override void Init(GameServices services) { }

		public void SetBuildings(TileBuildingRegistryItem[] buildings) {
			_buildings = buildings;
		}
	}
}