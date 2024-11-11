using System.Linq;
using UnityEngine;

namespace Game.Planets {
	public class InitPlanet: MonoBehaviour {
		[SerializeField] private Planet _planet;
		[SerializeField] private TileFacade _prefab;

		private void Awake() {
			_planet.GetComponentsInChildren<TileHolder>().ToList().ForEach(holder => InitHolder(holder));
			_planet.Graph.CreateNew();
			Debug.Log($"Planet init. Graph size: {_planet.Graph.Nodes.Count}");
			Destroy(this);
		}

		private void InitHolder(TileHolder holder) {
			holder.Init(_planet, holder.Id);
			var tile = Instantiate(_prefab);
			tile.AttachTo(holder);
		}
	}
}