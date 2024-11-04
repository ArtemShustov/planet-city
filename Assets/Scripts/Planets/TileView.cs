using UnityEngine;

namespace Game.Planets {
	[RequireComponent(typeof(Tile))]
	[SelectionBase]
	public class TileView: MonoBehaviour {
		[SerializeField] private float _highlightHeight;
		[SerializeField] private Transform _modelRoot;

		public Tile @Tile { get; private set; }

		protected virtual void Awake() {
			@Tile = GetComponent<Tile>();
		}

		public void AttachTo(TileHolder holder) {
			transform.parent = holder.transform;
			transform.localPosition = Vector3.zero;
			transform.localEulerAngles = Vector3.zero;
		}
		public void SetHighlight(bool state) {
			_modelRoot.localPosition = transform.up * (state ? _highlightHeight : 0);
		}
	}
}