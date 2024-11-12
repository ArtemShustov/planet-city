using Game.Tiles.Graph;
using Game.Tiles.PlanetResources;
using Game.Tiles.Resources;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Game.Tiles.Models {
	public class EnergyGeneratorModel: TileBuildingModel {
		[SerializeField] private int _power;
		[Min(0)]
		[SerializeField] private int _distance;

		private void AddEnergy(TileGraphNode node) {
			TileEnergy.AddFor(node.Tile, _power);
		}
		private void RemoveEnergy(TileGraphNode node) {
			TileEnergy.RemoveFor(node.Tile, _power);
		}

		public override void OnAttach() {
			base.OnAttach();
			Root.Tile.Planet.Graph.ForeachBFS(Root.Tile.Node, _distance + 1, AddEnergy);
		}
		public override void OnDetach() {
			Root.Tile.Planet.Graph.ForeachBFS(Root.Tile.Node, _distance + 1, RemoveEnergy);
			base.OnDetach();
		}
	}
}