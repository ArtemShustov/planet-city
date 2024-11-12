using Game.Tiles.PlanetResources;
using System;
using UnityEngine;

namespace Game.Tiles {
	[Serializable]
	public class PlanetResourcesContainer {
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
	}
}