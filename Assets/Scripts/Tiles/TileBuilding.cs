using Game.Utils;
using UnityEngine;

namespace Game.Tiles {
	public class TileBuilding: MonoBehaviour {
		[HideInPlayMode]
		[SerializeField] private TileBuildingModel _model;
		[HideInPlayMode]
		[SerializeField] private TileBuildingView _view;

		private Tile _root;
		private Planet _planet;

		public Tile Tile => _root;
		public Planet Planet => _planet;

		private void Awake() {
			_model.SetRoot(this);
			_view.SetRoot(this);
		}

		public virtual void OnAttach(Planet planet, Tile tile) {
			_root = tile;
			_planet = planet;
			_model.OnAttach();
			_view.OnAttach();
		}
		public virtual void OnDetach() {
			_model.OnDetach();
			_view.OnDetach();
			_root = null;
			_planet = null;
		}
	}
}