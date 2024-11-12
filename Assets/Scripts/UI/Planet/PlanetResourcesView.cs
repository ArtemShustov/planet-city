using Game.Ticking;
using Game.Tiles;
using UnityEngine;

namespace Game.UI.PlanetResources {
	public class PlanetResourcesView: MonoBehaviour {
		[SerializeField] private Planet _planet;
		[SerializeField] private TickGroup _group;
		[Space]
		[SerializeField] private Label _money;
		[SerializeField] private Label _population;
		[SerializeField] private Label _factoryPower;
		[SerializeField] private Bar _food;
		[SerializeField] private Bar _factory;
		[SerializeField] private Bar _houses;
		[SerializeField] private Bar _science;

		private void UpdateAll() {
			_money.UpdateLabel(_planet.Resources.Money.Value);
			_population.UpdateLabel(_planet.Resources.Population.Count);
			_factoryPower.UpdateLabel(_planet.Resources.Factory.Value);

			_food.SetFill(_planet.Resources.FoodFactor);
			_factory.SetFill(_planet.Resources.FoodFactor);
			_houses.SetFill(_planet.Resources.HousesFill);
			_science.SetFill(_planet.Resources.Research);
		}

		private void OnEnable() {
			_group.Tick += UpdateAll;
		}
		private void OnDisable() {
			_group.Tick -= UpdateAll;
		}
	}
}