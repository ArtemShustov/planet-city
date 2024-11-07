using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace Game.Ticking {
	public class Ticker: MonoBehaviour {
		[SerializeField] private float _tickDelay = 0.5f;
		[SerializeField] private List<TickGroup> _tickGroups = new List<TickGroup>();

		public float TickDelay => _tickDelay;
		public float TargetTickRate => _tickDelay / 1f;

		public event Action TickStart;
		public event Action TickEnd;

		private Coroutine _coroutine;

		private void OnEnable() {
			_coroutine = StartCoroutine(Loop());
		}
		private void OnDisable() {
			StopCoroutine(_coroutine);
		}

		private IEnumerator Loop() {
			while (true) {
				Profiler.BeginSample("Tick");
				TickStart?.Invoke();
				_tickGroups.ForEach(group => group.OnTick());
				TickEnd?.Invoke();
				Profiler.EndSample();
				yield return new WaitForSeconds(_tickDelay);
			}
		}
	}
}