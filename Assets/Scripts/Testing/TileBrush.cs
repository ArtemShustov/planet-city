using Game.Planets;
using Game.Utils;
using UnityEngine;

namespace Game.Testing {
	public class TileBrush: MonoBehaviour {
		[SerializeField] private int _fontSize = 48;
		[SerializeField] private TileFacadeSelector _selector;
		[SerializeField] private Planet _planet;
		[HideInPlayMode]
		[SerializeField] private TileFacade[] _prefabs;
		
		private GUIStyle _style;
		private int _selected;

		private void Update() {
			if (Input.GetKeyDown(KeyCode.E)) {
				_selected = Mathf.Clamp(_selected + 1, 0, _prefabs.Length - 1);
				Debug.Log($"Selected {_selected}: {_prefabs[_selected].name}");
			}
			if (Input.GetKeyDown(KeyCode.Q)) {
				_selected = Mathf.Clamp(_selected - 1, 0, _prefabs.Length - 1);
				Debug.Log($"Selected {_selected}: {_prefabs[_selected].name}");
			}
		}
		private void Paint(TileFacade tile) {
			var prefab = _prefabs[_selected];
			var newTile = Instantiate(prefab);
			_planet.Replace(tile, newTile);
			Destroy(tile.gameObject);
		}

		private void OnEnable() {
			_selector.Selected += Paint;
		}
		private void OnDisable() {
			_selector.Selected -= Paint;
		}

		private void OnGUI() {
			if (_style == null) {
				_style = new GUIStyle();
				_style.fontSize = _fontSize;
			}
			var rect = new Rect(0, Screen.height - _fontSize, 0, _fontSize);
			GUI.TextField(rect, $"Selected: {_prefabs[_selected]}", _style);
		}
		private void OnValidate() {
			if (Application.isPlaying) {
				_style = new GUIStyle();
				_style.fontSize = _fontSize;
			}
		}
	}
}