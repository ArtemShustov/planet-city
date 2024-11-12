using System;
using System.Collections.Generic;

namespace Game.Tiles {
	public class TileResources {
		private Dictionary<Type, ITileResource> _resources = new Dictionary<Type, ITileResource>();

		public bool TryGet<T>(out T resource)  where T: ITileResource {
			var result = _resources.TryGetValue(typeof(T), out var value);
			if (result) {
				resource = (T)value;
			} else {
				resource = default(T);
			}
			return result;
		}
		public bool Add<T>(T resource) where T: ITileResource {
			if (TryGet<T>(out var value)) {
				return false;
			}
			_resources.Add(typeof(T), resource);
			return true;
		}
		public void Remove<T>() where T: ITileResource {
			if (_resources.ContainsKey(typeof(T))) {
				_resources.Remove(typeof(T));
			}
		}
	}
}