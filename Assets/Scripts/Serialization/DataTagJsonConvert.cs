using Newtonsoft.Json;

namespace Game.Serialization {
	public static class DataTagJsonConvert {
		public static string ToJson(DataTag tag) {
			return JsonConvert.SerializeObject(tag, new JsonSerializerSettings() { 
				TypeNameHandling = TypeNameHandling.Auto,
			});
		}
		public static DataTag FromJson(string json) {
			return JsonConvert.DeserializeObject<DataTag>(json, new JsonSerializerSettings() {
				TypeNameHandling = TypeNameHandling.Auto,
			});
		}
	}
}