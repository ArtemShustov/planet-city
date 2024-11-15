using Game.Services;
using Game.TileRegistires;
using Game.Tiles;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI {
	public class BuildWindow: MonoBehaviour {
		[SerializeField] private GameObject _root;
		[SerializeField] private Transform _itemsRoot;
		[SerializeField] private BuildWindowItem _itemPrefab;

		private List<BuildWindowItem> _items = new List<BuildWindowItem>();
		private Tile _tile;

		private void Awake() {
			var items = GameServices.GetService<TileBuildingRegistryService>().Items;
			foreach (var item in items) {
				var instance = Instantiate(_itemPrefab, _itemsRoot);
				instance.SetData(item);
				instance.Clicked += OnBuildingSelected;
				_items.Add(instance);
			}
			Hide();
		}

		public void Show(Tile tile) {
			_tile = tile;
			_root.SetActive(true);
		}
		public void Hide() {
			_root.SetActive(false);
		}

		private void OnBuildingSelected(TileBuildingRegistryItem item) {
			if (_tile == null) {
				Hide();
				return;
			}
			var building = item.InstantiatePrefab();
			_tile.Planet.AttachBuilding(_tile, building);
			Hide();
		}

		private void OnDestroy() {
			_items.ForEach(i => i.Clicked -= OnBuildingSelected);
		}
	}
}