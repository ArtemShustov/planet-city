using Game.Graph;
using Game.Ticking;
using UnityEngine;

namespace Game.Planets {
	public class Planet: MonoBehaviour {
		[SerializeField] private TileGraph _graph;
		[SerializeField] private Ticker _ticker;
		[SerializeField] private PlanetResources _resources;

		public TileGraph Graph => _graph;
		public Ticker Ticker => _ticker;
		public PlanetResources Resources => _resources;

		public void Replace(TileFacade tile, TileFacade with) {
			var holder = tile.Holder;
			tile.Detach();
			with.AttachTo(holder);
			_graph.Replace(tile.Node, with.Node);
		}
	}
}