using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Game.Tiles.Editor {
	[CustomEditor(typeof(PlanetSetup))]
	public class InitPlanetEditor: UnityEditor.Editor {
		private string _pattern = @"^TileHolder\.\d{3}$";
		private string _holdersRoot = "Model";
		private GameObject[] _tileHolderObjects;

		private bool _foldout;

		public override void OnInspectorGUI() {
			DrawDefaultInspector();

			_foldout = EditorGUILayout.BeginFoldoutHeaderGroup(_foldout, "Tiles setup");
			if (_foldout) {
				_pattern = EditorGUILayout.TextField("Pattern", _pattern);
				if (GUILayout.Button("Generate")) {
					GenerateTileHolders();
				}
			}
			EditorGUILayout.EndFoldoutHeaderGroup();
			if (GUILayout.Button("Remove component")) {
				DestroyImmediate(target);
			}
		}

		private void GenerateTileHolders() {
			var setup = (PlanetSetup)target;
			var planet = setup.GetComponent<Planet>();
			if (planet == null) {
				Debug.LogWarning("Planet script not found!");
				return;
			}
			Transform modelTransform = planet.transform.Find(_holdersRoot);

			if (modelTransform == null) {
				Debug.LogWarning("Model object not found in Planet!");
				return;
			}

			_tileHolderObjects = FindMatchingChildren(modelTransform, _pattern);

			var id = 0;
			foreach (var holder in _tileHolderObjects) {
				setup.InitHolder(holder.transform, id);
				id += 1;
			}
		}

		private GameObject[] FindMatchingChildren(Transform parent, string pattern) {
			List<GameObject> matchingObjects = new System.Collections.Generic.List<GameObject>();

			foreach (Transform child in parent) {
				if (Regex.IsMatch(child.name, pattern)) {
					matchingObjects.Add(child.gameObject);
				}
			}

			return matchingObjects.ToArray();
		}
	}
}