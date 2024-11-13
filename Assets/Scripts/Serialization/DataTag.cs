using System;
using System.Collections.Generic;

namespace Game.Serialization {
	[Serializable]
	public class DataTag: ITag {
		[Newtonsoft.Json.JsonProperty]
		private Dictionary<string, object> _data = new Dictionary<string, object>();

		public void Set<T>(string key, T value) {
			if (_data.ContainsKey(key)) {
				_data[key] = value;
			} else {
				_data.Add(key, value);
			}
		}
		public T Get<T>(string key) {
			return (T)_data[key];
		}
		public bool TryGet<T>(string key, out T value) {
			if (_data.TryGetValue(key, out var obj)) {
				if (obj is T v) {
					value = v;
					return true;
				}
			}
			value = default(T);
			return false;
		}

		public void SetInt(string key, long value) => Set<long>(key, value);
		public bool TryGetInt(string key, out long value) => TryGet<long>(key, out value);

		public void SetString(string key, string value) => Set<string>(key, value);
		public bool TryGetString(string key, out string value) => TryGet<string>(key, out value);
	}
}