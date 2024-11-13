namespace Game.Tiles {
	public interface ITileBuildingComponent {
		void SetRoot(TileBuilding root);

		void OnAttach();
		void OnDetach();
	}
}