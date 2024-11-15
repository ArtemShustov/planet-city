using Game.TileRegistires;
using System;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace Game.UI {
	public class BuildingInfoView: MonoBehaviour {
		[SerializeField] private GameObject _root;
		[SerializeField] private LocalizeStringEvent _name;
		[SerializeField] private LocalizeStringEvent _description;
		[SerializeField] private Button _demolitionButton;

		public event Action DemolitionSelected;

		private void Awake() {
			Hide();
		}

		public void Show(TileBuildingRegistryItem item) {
			_root.SetActive(true);
			_name.StringReference = item.Name;
			_name.RefreshString();
			_description.StringReference = item.Description;
			_description.RefreshString();
		}
		public void Hide() {
			_root.SetActive(false);
		}

		private void OnDemolitionButton() {
			DemolitionSelected?.Invoke();
		}

		private void OnEnable() {
			_demolitionButton?.onClick.AddListener(OnDemolitionButton);
		}
		private void OnDisable() {
			_demolitionButton?.onClick.RemoveListener(OnDemolitionButton);
		}
	}
}