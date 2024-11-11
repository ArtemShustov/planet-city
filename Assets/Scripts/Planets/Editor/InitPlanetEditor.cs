using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Game.Planets.EditorTools {
	[CustomEditor(typeof(InitPlanet))]
	public class InitPlanetEditor: Editor {
		private string _pattern = @"^TileHolder\.\d{3}$";
		private string _holdersRoot = "Model";
		private GameObject[] _tileHolderObjects;

		private bool _foldout;

		public override void OnInspectorGUI() {
			DrawDefaultInspector();

			_foldout = EditorGUILayout.BeginFoldoutHeaderGroup(_foldout, "Holders setup");
			if (_foldout) {
				_pattern = EditorGUILayout.TextField("Pattern", _pattern);
				if (GUILayout.Button("Generate")) {
					GenerateTileHolders();
				}
			}
			EditorGUILayout.EndFoldoutHeaderGroup();
		}

		private void GenerateTileHolders() {
			Planet planet = ((InitPlanet)target).GetComponent<Planet>();
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

			var id = 1;
			foreach (var obj in _tileHolderObjects) {
				if (obj.TryGetComponent<TileHolder>(out var holder)) {
					holder.Init(planet, id);
				} else {
					obj.AddComponent<TileHolder>().Init(planet, id);
				}
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