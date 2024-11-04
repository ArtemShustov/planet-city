using Game.Planets;
using UnityEngine;

namespace Game {
	public class TileHighlighter: MonoBehaviour {
		[SerializeField] private TileSelector _selector;

		private Tile _current;

		private void Update() {
			if (_selector.TrySelectUnderPointer(out var tile)) {
				if (_current == tile) {
					return;
				}
				if (_current != null) { 
					_current.View.SetHighlight(false);
				}
				_current = tile;
				_current.View.SetHighlight(true);
			} else if (_current != null) {
				_current.View.SetHighlight(false);
				_current = null;
			}
		}
	}
}