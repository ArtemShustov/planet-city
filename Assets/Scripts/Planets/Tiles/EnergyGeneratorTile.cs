using Game.Graph;
using Game.Planets.TileResources;
using Game.Utils;
using UnityEngine;

namespace Game.Planets.Tiles {
	public class EnergyGeneratorTile: Tile {
		[Min(0), HideInPlayMode]
		[SerializeField] private int _power;
		[Min(0), HideInPlayMode]
		[SerializeField] private int _distance;

		private void AddEnergyAll() {
			Planet.Graph.ForeachBFS(Root.Node, _distance, AddEnergy);
		}
		private void RemoveEnergyAll() {
			Planet.Graph.ForeachBFS(Root.Node, _distance, RemoveEnergy);
		}
		private void AddEnergy(TileGraphNode node) {
			Energy.AddFor(node.Root.Holder, _power);
		}
		private void RemoveEnergy(TileGraphNode node) {
			Energy.RemoveFor(node.Root.Holder, _power);
		}

		public override void OnAttach(Planet planet) {
			base.OnAttach(planet);
			AddEnergyAll();
		}
		public override void OnDetach(Planet planet) {
			RemoveEnergyAll();
			base.OnDetach(planet);
		}
	}
}