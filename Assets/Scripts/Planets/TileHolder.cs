using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Planets {
	public class TileHolder: MonoBehaviour {
		private ITile _tile;
		private Planet _planet;
		private Dictionary<Type, ITileResource> _resources = new Dictionary<Type, ITileResource>();

		public bool IsFree => _tile == null;
		public ITile Tile => _tile;
		public Planet Planet => _planet;
		public IReadOnlyCollection<ITileResource> Resources => _resources.Values;

		public void Init(Planet planet) {
			_planet = planet;
		}

		public void Attach(ITile tile) {
			_tile = tile;
			_tile.OnAttach(_planet);
		}
		public void Detach() {
			_tile.OnDetach(_planet);
			_tile = null;
		}

		public void AddResource<T>(T resource) where T: ITileResource {
			if (_resources.ContainsKey(resource.GetType())) {
				return;
			}
			_resources.Add(resource.GetType(), resource);
		}
		public T GetResource<T>() where T: ITileResource {
			return (T)_resources[typeof(T)];
		}
		public bool TryGetResource<T>(out T resource) where T: ITileResource {
			if (_resources.ContainsKey(typeof(T))) {
				resource = (T)_resources[typeof(T)];
				return true;
			}
			resource = default;
			return false;
		}
		public T GetOrCreateResource<T>(Func<T> constructor) where T: ITileResource {
			if (TryGetResource<T>(out var resource)) {
				return resource;
			}
			resource = constructor.Invoke();
			AddResource(resource);
			return resource;
		}

		private void OnDrawGizmos() {
			Gizmos.DrawWireSphere(transform.position, 0.5f);
			Gizmos.DrawLine(transform.position, transform.position + transform.up);
		}
	}
}