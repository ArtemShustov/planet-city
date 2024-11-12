using Game.Ticking;
using Game.Utils;
using UnityEngine;

namespace Game.Tiles.Models {
	public abstract class TickableModel: TileBuildingModel {
		[HideInPlayMode]
		[SerializeField] private TickGroup _group;

		public abstract void OnTick();

		public override void OnAttach() {
			base.OnAttach();
			_group.Tick += OnTick;
		}
		public override void OnDetach() {
			_group.Tick -= OnTick;
			base.OnDetach();
		}

		protected virtual void OnDestroy() {
			_group.Tick -= OnTick;
		}
	}
}