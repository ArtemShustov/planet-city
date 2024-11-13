namespace Game.Serialization {
	public interface ISerializableComponent {
		void WriteToTag(DataTag tag);
		void ReadFromTag(DataTag tag);
	}
}