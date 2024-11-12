using Game.Planets;
using UnityEngine;

namespace Game.TileRegistires {
	[CreateAssetMenu(menuName = "Registry/Tile")]
	public class TileRegistyItem: ScriptableObject {
		[SerializeField] private TileFacade _prefab;
		[SerializeField] private string _id;

		public string Id => _id;
		public TileFacade Prefab => _prefab;

		public void SetData(string id, TileFacade prefab) {
			_id = id;
			_prefab = prefab;
		}
	}
}