using Game.Utils;
using System;
using UnityEngine;

namespace Game.Tiles {
	public class TileBuilding: MonoBehaviour, ITileBuilding {
		[HideInPlayMode]
		[SerializeField] private TileBuildingModel _model;
		[HideInPlayMode]
		[SerializeField] private TileBuildingView _view;

		private ITile _root;
		private Planet _planet;

		public event Action Attached;
		public event Action Detached;

		public ITile Tile => _root;
		public Planet Planet => _planet;

		private void Awake() {
			_model.SetRoot(this);
			_view.SetRoot(this);
		}

		public virtual void OnAttach(Planet planet, ITile tile) {
			_root = tile;
			_planet = planet;
			Attached?.Invoke();
		}
		public virtual void OnDetach(Planet planet, ITile tile) {
			_root = null;
			_planet = null;
			Detached?.Invoke();
		}
	}
}