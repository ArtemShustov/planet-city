using UnityEngine;

namespace Game.Planets {
	[SelectionBase]
	public class TileView: MonoBehaviour, ITileComponent {
		[SerializeField] private float _highlightHeight;
		[SerializeField] private Transform _modelRoot;

		public TileFacade Root { get; private set; }

		public void AttachTo(TileHolder holder) {
			transform.parent = holder.transform;
			transform.localPosition = Vector3.zero;
			transform.localEulerAngles = Vector3.zero;
		}
		public void SetHighlight(bool state) {
			_modelRoot.localPosition = transform.up * (state ? _highlightHeight : 0);
		}

		public void SetCompositionRoot(TileFacade root) => Root = root;
	}
}