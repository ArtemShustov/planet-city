using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

namespace Game.Planets {
	public class Planet: MonoBehaviour {
		[SerializeField] private TileHolder[] _holders;

		public event Action Tick;

		public IReadOnlyCollection<TileHolder> Holders => _holders;

		public void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				Debug.Log("Planet tick.");
				Profiler.BeginSample("Planet tick");
				Tick?.Invoke();
				Profiler.EndSample();
			}
		}
		public TileHolder GetHolderOf(ITile tile) {
			return _holders.First(holder => holder.Tile == tile);
		}
	}
}