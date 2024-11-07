using Game.Ticking;
using Game.Utils;
using UnityEngine;

namespace Game.Planets.Tiles {
	public abstract class TickableTile: Tile {
		[HideInPlayMode]
		[SerializeField] private TickGroup _tickGroup;
		private bool _attached = false;

		protected abstract void OnTick();

		public override void OnAttach(Planet planet) {
			if (_attached) {
				_tickGroup.Tick -= OnTick;
			}

			base.OnAttach(planet);
			_tickGroup.Tick += OnTick;
			_attached = true;
		}
		public override void OnDetach(Planet planet) {
			_tickGroup.Tick -= OnTick;
			_attached = false;
			base.OnDetach(planet);
		}

		protected virtual void OnEnable() {
			if (_attached) {
				_tickGroup.Tick += OnTick;
			}
		}
		protected virtual void OnDisable() {
			if (_attached) {
				_tickGroup.Tick -= OnTick;
			}
		}
	}
}