using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.UI.PlanetResources {
	public class PlanetResourcesViews: MonoBehaviour {
		[SerializeField] private Planets.PlanetResources _resources;

		private List<IPlanetResourceView> _views = new List<IPlanetResourceView>();

		private void Awake() {
			UpdateList();
			UpdateViews();
		}

		public void SetResources(Planets.PlanetResources resources) {
			_resources = resources;
			UpdateViews();
		}

		private void UpdateList() {
			_views = GetComponentsInChildren<IPlanetResourceView>().ToList();
		}
		private void UpdateViews() {
			_views.ForEach(view => view.SetResources(_resources));
		}
	}
}