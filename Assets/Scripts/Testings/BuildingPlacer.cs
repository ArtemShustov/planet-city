using Game.Tiles;
using UnityEngine;

namespace Game.Testing {
	public class BuildingPlacer: MonoBehaviour {
		[SerializeField] private TileBuilding[] _prefabs;
		[SerializeField] private TileSelector _selector;

		private TileBuilding _current;
		private int _index = 0;

		private void Awake() {
			Select(_index);
		}
		private void Update() {
			if (Input.GetKeyDown(KeyCode.Q)) {
				Select(_index - 1);
			}
			if (Input.GetKeyDown(KeyCode.E)) {
				Select(_index + 1);
			}
		}

		public void OnSelect(Tile tile) {
			var building = Instantiate(_current);
			var old = tile.Planet.ReplaceBuilding(tile, building);
			if (old is MonoBehaviour obj) {
				Destroy(obj.gameObject);
			}
		}
		private void Select(int index) {
			_index = Mathf.Clamp(index, 0, _prefabs.Length - 1);
			_current = _prefabs[_index];
			Debug.Log($"Selected: {_current.name}");
		}

		private void OnEnable() {
			_selector.Selected += OnSelect;
		}
		private void OnDisable() {
			_selector.Selected -= OnSelect;
		}
	}
}