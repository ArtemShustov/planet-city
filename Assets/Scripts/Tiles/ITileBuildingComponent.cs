namespace Game.Tiles {
	public interface ITileBuildingComponent {
		void SetRoot(ITileBuilding root);

		void OnAttach();
		void OnDetach();
	}
}