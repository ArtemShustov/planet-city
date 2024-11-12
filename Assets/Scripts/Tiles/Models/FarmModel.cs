using UnityEngine;

namespace Game.Tiles.Models {
	public class FarmModel: TileBuildingModel {
		[SerializeField] private int _count;

		public override void OnAttach() {
			base.OnAttach();
			Root.Tile.Planet.Resources.Food.Add(_count);
		}
		public override void OnDetach() {
			Root.Tile.Planet.Resources.Food.Remove(_count);
			base.OnDetach();
		}
	}
}