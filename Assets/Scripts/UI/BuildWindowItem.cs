using Game.TileRegistires;
using Game.Tiles;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace Game.UI {
	public class BuildWindowItem: MonoBehaviour, IPointerClickHandler {
		[SerializeField] private Image _icon;
		[SerializeField] private LocalizeStringEvent _shortDescription;

		private TileBuildingRegistryItem _item;

		public event Action<TileBuildingRegistryItem> Clicked;

		public void SetData(TileBuildingRegistryItem item) {
			_item = item;
			_icon.sprite = item.Icon;
			_shortDescription.StringReference = item.ShortDescription;
			_shortDescription.RefreshString();
		}

		public void OnPointerClick(PointerEventData eventData) {
			Clicked?.Invoke(_item);
		}
	}
}