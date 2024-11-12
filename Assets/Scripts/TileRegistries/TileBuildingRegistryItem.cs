using Game.Tiles;
using UnityEngine;

namespace Game.TileRegistires {
	[CreateAssetMenu(menuName = "Registry/TileBuilding")]
	public class TileBuildingRegistryItem: ScriptableObject {
		[SerializeField] private TileBuilding _prefab;
		[SerializeField] private string _id;

		public string Id => _id;
		public TileBuilding Prefab => _prefab;

		public void SetData(string id, TileBuilding prefab) {
			_id = id;
			_prefab = prefab;
		}
	}
}