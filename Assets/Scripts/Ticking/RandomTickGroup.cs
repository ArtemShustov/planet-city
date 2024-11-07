using UnityEngine;

namespace Game.Ticking {
	[CreateAssetMenu(menuName = "Ticking/RandomTickGroup")]
	public class RandomTickGroup: TickGroup {
		[Min(1)]
		[SerializeField] private int _random = 1;

		public override void OnTick() {
			if (UnityEngine.Random.Range(0, _random + 1) == 0) {
				base.OnTick();
			}
		}
	}
}