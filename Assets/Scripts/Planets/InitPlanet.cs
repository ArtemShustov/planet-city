using System.Linq;
using UnityEngine;

namespace Game.Planets {
	public class InitPlanet: MonoBehaviour {
		[SerializeField] private Planet _planet;
		[SerializeField] private TileFacade _prefab;

		private void Awake() {
			_planet.Holders.ToList().ForEach(holder => InitHolder(holder));
			Debug.Log("Planet init");
			Destroy(this);
		}

		private void InitHolder(TileHolder holder) {
			holder.Init(_planet);
			var tile = Instantiate(_prefab);
			tile.AttachTo(holder);
		}
	}
}