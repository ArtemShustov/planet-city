using Game.Tiles.Graph;

namespace Game.Tiles {
	public interface ITile {
		ITileBuilding Building { get; }
		TileResources Resources { get; }
		Planet Planet { get; }
		TileGraphNode Node { get; }

		void SetPlanet(Planet planet);

		void OnAttach(ITileBuilding building);
		void OnDetach(ITileBuilding building);
	}
}