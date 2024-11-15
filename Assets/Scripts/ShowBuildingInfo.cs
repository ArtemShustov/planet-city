using Game.Serialization;
using Game.Services;
using Game.TileRegistires;
using Game.Tiles;
using Game.UI;
using UnityEngine;

namespace Game {
	public class ShowBuildingInfo: MonoBehaviour {
		[SerializeField] private TileSelector _selector;
		[SerializeField] private BuildingInfoView _view;

		private TileBuildingRegistryService _registry;
		private Tile _selectedTile;

		private void Start() {
			_registry = GameServices.GetService<TileBuildingRegistryService>();
		}

		public void DestroyBuilding() {
			if (_selectedTile != null && _selectedTile.Building != null) {
				var building = _selectedTile.Planet.DetachBuilding(_selectedTile);
				Destroy(building.gameObject);
				_view.Hide();
			}
		}

		private void OnSelected(Tile tile) {
			if (tile.Building == null) {
				_view.Hide();
				return;
			}
			if (tile.Building.TryGetComponent<SerializableObject>(out var serializable)) {
				if (_registry.TryGet(serializable.Id, out var item)) {
					_selectedTile = tile;
					_view.Show(item);
				}
			}
		}
		private void OnNotSelected() {
			_view.Hide();
		}

		private void OnEnable() {
			_selector.Selected += OnSelected;
			_selector.NotSelected += OnNotSelected;
			_view.DemolitionSelected += DestroyBuilding;
		}
		private void OnDisable() {
			_selector.Selected -= OnSelected;
			_selector.NotSelected -= OnNotSelected;
			_view.DemolitionSelected -= DestroyBuilding;
		}
	}
}