using System.Linq;
using UnityEngine;

namespace Game.Serialization {
	public class SerializableObject: MonoBehaviour {
		[SerializeField] private string _id;

		public void SetId(string id) => _id = id;

		public void WriteTag(DataTag tag) {
			tag.SetString(nameof(_id), _id);
			GetComponents<ISerializableComponent>().ToList().ForEach(c => c.WriteToTag(tag));
		}
		public void ReadFromTag(DataTag tag) {
			GetComponents<ISerializableComponent>().ToList().ForEach(c => c.ReadFromTag(tag));
		}
	}
}