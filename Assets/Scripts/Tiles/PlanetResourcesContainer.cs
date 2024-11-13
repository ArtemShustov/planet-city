using Game.Serialization;
using Game.Tiles.PlanetResources;
using System;
using UnityEngine;

namespace Game.Tiles {
	[Serializable]
	public class PlanetResourcesContainer: ISerializableComponent {
		public Money Money { get; private set; } = new Money();
		public Population Population { get; private set; } = new Population();
		public Food Food { get; private set; } = new Food();
		public Factory Factory { get; private set; } = new Factory();
		public Science Science { get; private set; } = new Science();

		public float FoodFactor => Population.Max == 0 ? 1f : Mathf.Clamp01((float)Food.Value / Population.Max);
		public float FactoryFill => Population.Used == 0 ? 1f : Mathf.Clamp01((float)Population.Count / Population.Used);
		public float EfficiencyThrottle => Population.Count == 0 ? 0f : Mathf.Max(1, (float)Population.Used / Population.Count) - 1;
		public float HousesFill => Population.Max == 0 ? 0 : Mathf.Clamp01((float)Population.Count / Population.Max);
		public float Research => Science.Target == 0 ? 0 : Mathf.Clamp01((float)Science.Value / Science.Target);

		public void WriteToTag(DataTag tag) {
			tag.SetInt("Money.Value", Money.Value);
			tag.SetInt("Science.Value", Science.Value);
		}
		public void ReadFromTag(DataTag tag) {
			if (tag.TryGetInt("Money.Value", out var money)) {
				Money.Add((int)money);
			}
			if (tag.TryGetInt("Science.Value", out var science)) {
				Science.Add((int)science);
			}
		}
	}
}