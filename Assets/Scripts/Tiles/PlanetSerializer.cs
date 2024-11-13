using Game.Serialization;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Game.Services;
using Game.TileRegistires;

namespace Game.Tiles {
	public class PlanetSerializer: MonoBehaviour {
		[SerializeField] private Planet _planet;

		private string _json;

		private const string _tileIdName = "tileId";
		private const string _tilesName = "tiles";
		private const string _resourcesName = "resources";

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Keypad4)) {
				_json = Serialize();
				Debug.Log(_json);
			}
			if (Input.GetKeyDown(KeyCode.Keypad6)) {
				Clear();
				Deserialize(_json);
			}
		}

		public string Serialize() {
			var root = new DataTag();

			var list = new List<DataTag>();
			foreach (var tile in _planet.Tiles) {
				if (tile.Building != null && tile.Building.TryGetComponent<SerializableObject>(out var serializable)) {
					var tileTag = new DataTag();
					tileTag.SetInt(_tileIdName, tile.Id);
					serializable.WriteTag(tileTag);
					list.Add(tileTag);
				}
			}
			root.Set(_tilesName, list);

			var resources = new DataTag();
			_planet.Resources.WriteToTag(root);
			root.Set(_resourcesName, resources);

			var json = DataTagJsonConvert.ToJson(root);
			return json;
		}
		public void Clear() {
			_planet.Tiles.ToList().ForEach(t => {
				if (t.Building) {
					Destroy(_planet.DetachBuilding(t).gameObject);
				}
			});
		}
		public void Deserialize(string json) {
			var tiles = new Dictionary<int, Tile>();
			_planet.Tiles.ToList().ForEach(t => tiles.Add(t.Id, t));

			var root = DataTagJsonConvert.FromJson(json);
			var list = root.Get<List<DataTag>>(_tilesName);
            foreach (var buildingTag in list) {
				if (buildingTag.TryGetInt(_tileIdName, out var tileId)) {
					// Debug.Log($"Tile id: {tileId}");
					if (tiles.TryGetValue((int)tileId, out var tile)) {
						// Debug.Log($"Tile: {tile.name}");
						if (buildingTag.TryGetString("_id", out string buildingId)) {
							// Debug.Log($"Building id: {buildingId}");
							if (GameServices.GetService<TileBuildingRegistryService>().TryGet(buildingId, out var registryItem)) {
								// Debug.Log($"Registry id: {registryItem.Id}");
								var instance = Instantiate(registryItem.Prefab);
								_planet.AttachBuilding(tile, instance);
							}
						}
					}
				}
            }

			_planet.ClearResources();
			var resources = root.Get<DataTag>(_resourcesName);
			_planet.Resources.ReadFromTag(resources);
        }
	}
}