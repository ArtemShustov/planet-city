namespace Game.Planets {
	public interface ITileComponent {
		public TileFacade Root { get; }
		public void SetCompositionRoot(TileFacade root);
	}
}