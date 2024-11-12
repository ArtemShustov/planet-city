using UnityEngine;

namespace Game.Tiles {
	[RequireComponent(typeof(Planet))]
	public class PlanetSetup: MonoBehaviour {
		[SerializeField] private Tile _prefab;

		public void InitHolder(Transform holder, int id) {
			var tile = Instantiate(_prefab, holder);
			tile.transform.position = holder.position;
			tile.transform.rotation = holder.rotation;
		}
	}
}