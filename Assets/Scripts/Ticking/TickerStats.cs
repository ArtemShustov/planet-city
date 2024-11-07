using UnityEngine;

namespace Game.Ticking {
	public class TickerStats: MonoBehaviour {
		[SerializeField] private Ticker _ticker;

		private System.Diagnostics.Stopwatch _watch = new();

		private void OnTickStart() {
			_watch.Restart();
		}
		private void OnTickEnd() {
			_watch.Stop();
			Debug.Log($"Tick time: {_watch.ElapsedMilliseconds} ms");
		}

		private void OnEnable() {
			_ticker.TickStart += OnTickStart;
			_ticker.TickEnd += OnTickEnd;
		}
		private void OnDisable() {
			_ticker.TickStart -= OnTickStart;
			_ticker.TickEnd -= OnTickEnd;
		}
	}
}