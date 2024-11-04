using Game.Planets;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game {
	public class TileFacadeSelector: MonoBehaviour {
		[SerializeField] private LayerMask _mask;
		[SerializeField] private Camera _camera;
		[SerializeField] private InputAction _input;

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

		private void OnClick(InputAction.CallbackContext obj) {
			if (TrySelectUnderPointer(out var tile)) {
				Selected?.Invoke(tile);
			} else {
				NotSelected?.Invoke();
			}
		}

		private void OnEnable() {
			_input.Enable();
			_input.performed += OnClick;
		}
		private void OnDisable() {
			_input.Disable();
			_input.performed -= OnClick;
		}
	}
}