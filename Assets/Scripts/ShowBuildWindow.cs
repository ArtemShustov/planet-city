using Game.Tiles;
using Game.UI;
using UnityEngine;

namespace Game {
	public class ShowBuildWindow: MonoBehaviour {
		[SerializeField] private TileSelector _selector;
		[SerializeField] private BuildWindow _view;

		public void OnSelected(Tile tile) {
			if (tile.Building != null) {
				_view.Hide();
				return;
			}
			_view.Show(tile);
		}
		public void OnNotSelected() {
			_view.Hide();
		}

		private void OnEnable() {
			_selector.Selected += OnSelected;
			_selector.NotSelected += OnNotSelected;
		}
		private void OnDisable() {
			_selector.Selected -= OnSelected;
			_selector.NotSelected -= OnNotSelected;
		}
	}
}