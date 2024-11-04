namespace Game.Planets {
	public interface ITile {
		void OnAttach(Planet planet);
		void OnDetach(Planet planet);
	}
}