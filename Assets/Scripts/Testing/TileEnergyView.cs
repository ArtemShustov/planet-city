using Game.Planets.TileResources;
using UnityEngine;

namespace Game.Testing {
	public class TileEnergyView: MonoBehaviour {
		[SerializeField] private int _fontSize = 48;
		[SerializeField] private TileFacadeSelector _selector;

		private GUIStyle _style;

		private void OnGUI() {
			if (_selector.TrySelectUnderPointer(out var tile)) {
				if (tile.Holder.TryGetResource<Energy>(out var energy)) {
					var rect = new Rect(Input.mousePosition.x, Input.mousePosition.y, 1, _fontSize);
					GUI.TextField(rect, $"Energy: {energy.Value}", _style);
				}
			}
		}
		private void OnValidate() {
			if (Application.isPlaying) {
				_style = new GUIStyle();
				_style.fontSize = _fontSize;
			}
		}
	}
}