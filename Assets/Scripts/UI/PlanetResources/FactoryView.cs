using Game.Ticking;
using TMPro;
using UnityEngine;

namespace Game.UI.PlanetResources {
	public class FactoryView: MonoBehaviour, IPlanetResourceView {
		[SerializeField] private string _pattern = "{0}";
		[SerializeField] private TMP_Text _label;
		[SerializeField] private Planets.PlanetResources _resources;
		[SerializeField] private TickGroup _tick;

		public void SetResources(Planets.PlanetResources resources) => _resources = resources;

		private void UpdateLaber() {
			if (_resources == null) {
				return;
			}
			_label.text = string.Format(_pattern, _resources.FactoryPower.Value);
		}

		private void OnEnable() {
			_tick.Tick += UpdateLaber;
			UpdateLaber();
		}
		private void OnDisable() {
			_tick.Tick -= UpdateLaber;
		}
	}
}