using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using Game.Tiles;
using Game.Serialization;

namespace Game.TileRegistires.EditorTools {
	[CustomEditor(typeof(TileBuildingRegistryService))]
	public class TileBuildingRegistryServiceEditor: Editor {
		private string _itemsPath = "Data/Buildings";
		private string _prefabsPath = "Prefabs/Buildings";

		private bool _foldout;

		public override void OnInspectorGUI() {
			DrawDefaultInspector();
			
			EditorGUILayout.Separator();
			_foldout = EditorGUILayout.BeginFoldoutHeaderGroup(_foldout, "Setup");
			if (_foldout) {
				_prefabsPath = EditorGUILayout.TextField("Prefabs path", _prefabsPath);
				if (GUILayout.Button($"Create items from Assets/{_prefabsPath}/")) {
					CreateItems();
				}

				_itemsPath = EditorGUILayout.TextField("Registy items path", _itemsPath);
				if (GUILayout.Button($"Load items from Assets/{_itemsPath}/")) {
					LoadItems();
				}

				if (GUILayout.Button("Create icons")) {
					GenerateIcons();
				}
			}
			EditorGUILayout.EndFoldoutHeaderGroup();
		}
		private void LoadItems() {
			var service = (TileBuildingRegistryService)target;

			var files = Directory.GetFiles("Assets/" + _itemsPath, "*.asset", SearchOption.AllDirectories);
			var list = new List<TileBuildingRegistryItem>();
			foreach (var file in files) {
				var asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(file);
				if (asset is TileBuildingRegistryItem tile) {
					list.Add(tile);
					Debug.Log($"Added '{tile.name}' with id '{tile.Id}' and prefab '{tile.Prefab.name}'.");
				}
			}
			Debug.Log($"Total: {list.Count}");

			service.SetBuildings(list.ToArray());
			EditorUtility.SetDirty(service);
		}
		private void CreateItems() {
			var files = Directory.GetFiles("Assets/" + _prefabsPath, "*.prefab", SearchOption.AllDirectories);
			foreach (var file in files) {
				var asset = AssetDatabase.LoadAssetAtPath<TileBuilding>(file);
				if (asset is TileBuilding prefab) {
					var item = ScriptableObject.CreateInstance<TileBuildingRegistryItem>();
					item.SetData(prefab.name, prefab);
					if (prefab.TryGetComponent<SerializableObject>(out var serializable)) {
						serializable.SetId(prefab.name);
						EditorUtility.SetDirty(prefab);
					}
					EditorUtility.SetDirty(item);
					AssetDatabase.CreateAsset(item, $"Assets/{_itemsPath}/{item.Id}.asset");
					Debug.Log($"Created item for '{prefab.name}' with id '{item.Id}'.");
				}
			}
		}
		private void GenerateIcons() {
			var files = Directory.GetFiles("Assets/" + _itemsPath, "*.asset", SearchOption.AllDirectories);
			if (!Directory.Exists($"Assets/{_itemsPath}/icons")) {
				AssetDatabase.CreateFolder($"Assets/{_itemsPath}", "icons");
			}
			RuntimePreviewGenerator.BackgroundColor = Color.gray;
			RuntimePreviewGenerator.MarkTextureNonReadable = false;
			RuntimePreviewGenerator.PreviewDirection = new Vector3(0, -0.5f, 1);

			foreach (var file in files) {
				var asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(file);
				if (asset is TileBuildingRegistryItem item) {
					var texture = RuntimePreviewGenerator.GenerateModelPreview(item.Prefab.transform, width: 256, height: 256);
					File.WriteAllBytes($"Assets/{_itemsPath}/icons/{item.name}.png", texture.EncodeToPNG());
					Debug.Log($"Created icon for '{item.Id}'.");
				}
			}

			AssetDatabase.Refresh();
		}
	}
}