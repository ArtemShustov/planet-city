namespace Game.Tiles {
	public interface ITileBuilding { 
		ITile Tile { get; }

		void OnAttach(Planet planet, ITile tile);
		void OnDetach(Planet planet, ITile tile);
	}
}