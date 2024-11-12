using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using Game.Planets;

namespace Game.TileRegistires.EditorTools {
	[CustomEditor(typeof(TileRegistryService))]
	public class TileRegistryServiceEditor: Editor {
		private string _itemsPath = "Data/Tiles";
		private string _prefabsPath = "Prefabs/Tiles";

		private bool _foldout;

		public override void OnInspectorGUI() {
			DrawDefaultInspector();
			
			EditorGUILayout.Separator();
			_foldout = EditorGUILayout.BeginFoldoutHeaderGroup(_foldout, "Setup");
			if (_foldout) {
				_prefabsPath = EditorGUILayout.TextField("Prefabs path", _prefabsPath);
				if (GUILayout.Button($"Create items from Assets/{_itemsPath}/")) {
					CreateItems();
				}

				_itemsPath = EditorGUILayout.TextField("Registy items path", _itemsPath);
				if (GUILayout.Button($"Load from Assets/{_itemsPath}/")) {
					LoadFromFolder();
				}
			}
			EditorGUILayout.EndFoldoutHeaderGroup();
		}
		private void LoadFromFolder() {
			var service = (TileRegistryService)target;

			var files = Directory.GetFiles("Assets/" + _itemsPath, "*.asset", SearchOption.AllDirectories);
			var list = new List<TileRegistyItem>();
			foreach (var file in files) {
				var asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(file);
				if (asset is TileRegistyItem tile) {
					list.Add(tile);
					Debug.Log($"Added '{tile.name}' with id '{tile.Id}' and prefab '{tile.Prefab.name}'.");
				}
			}
			Debug.Log($"Total: {list.Count}");

			service.SetTiles(list.ToArray());
		}
		private void CreateItems() {
			var files = Directory.GetFiles("Assets/" + _prefabsPath, "*.prefab", SearchOption.AllDirectories);
			foreach (var file in files) {
				var asset = AssetDatabase.LoadAssetAtPath<TileFacade>(file);
				if (asset is TileFacade tile) {
					var item = ScriptableObject.CreateInstance<TileRegistyItem>();
					item.SetData(tile.name, tile);
					AssetDatabase.CreateAsset(item, $"Assets/{_itemsPath}/{item.Id}.asset");
					Debug.Log($"Created item for '{tile.name}' with id '{item.Id}'.");
				}
			}
		}
	}
}