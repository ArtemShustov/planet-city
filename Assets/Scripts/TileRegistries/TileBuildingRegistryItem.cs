using Game.Tiles;
using UnityEngine;
using UnityEngine.Localization;

namespace Game.TileRegistires {
	[CreateAssetMenu(menuName = "Registry/TileBuilding")]
	public class TileBuildingRegistryItem: ScriptableObject {
		[SerializeField] private TileBuilding _prefab;
		[SerializeField] private string _id;
		[Space]
		[SerializeField] private Sprite _icon;
		[SerializeField] private LocalizedString _name;
		[SerializeField] private LocalizedString _description;
		[SerializeField] private LocalizedString _shortDescription;

		public string Id => _id;
		public TileBuilding Prefab => _prefab;
		public Sprite Icon => _icon;
		public LocalizedString Name => _name;
		public LocalizedString Description => _description;
		public LocalizedString ShortDescription => _shortDescription;

		public void SetData(string id, TileBuilding prefab) {
			_id = id;
			_prefab = prefab;
		}

		public virtual TileBuilding InstantiatePrefab() {
			return Instantiate(_prefab);
		}
	}
}