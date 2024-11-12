using Game.Planets;
using System;
using UnityEngine;

namespace Game {
	public class TileFacadeSelector: MonoBehaviour {
		[SerializeField] private LayerMask _mask;
		[SerializeField] private Camera _camera;
		[SerializeField] private ClickWithoutMovement _input;

		public event Action<TileFacade> Selected;
		public event Action NotSelected;

		public bool TrySelectUnderPointer(out TileFacade tile) {
			var ray = _camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out var hit, maxDistance: 100, layerMask: _mask)) {
				return hit.collider.TryGetComponent<TileFacade>(out tile);
			}
			tile = null;
			return false;
		}

		private void OnClick() {
			if (TrySelectUnderPointer(out var tile)) {
				Selected?.Invoke(tile);
			} else {
				NotSelected?.Invoke();
			}
		}

		private void OnEnable() {
			_input.Performed += OnClick;
		}
		private void OnDisable() {
			_input.Performed -= OnClick;
		}
	}
}