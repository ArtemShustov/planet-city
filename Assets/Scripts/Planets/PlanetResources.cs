using Game.Planets.Resources;
using UnityEngine;

namespace Game.Planets {
	public class PlanetResources: MonoBehaviour {
		public Food Food { get; private set; } = new Food();
		public Population Population { get; private set; } = new Population();
		public FactoryPower FactoryPower { get; private set; } = new FactoryPower();
		public Science Science { get; private set; } = new Science();

		public float FoodFactor => Population.Max == 0 ? 0f : Mathf.Clamp01((float)Food.Value / Population.Max);
		public float EfficiencyThrottle => Population.Count == 0 ? 0f : Mathf.Max(1, (float)Population.Used / Population.Count) - 1;
	}
}