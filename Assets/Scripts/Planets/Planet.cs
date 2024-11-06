using Game.Graph;
using System;
using UnityEngine;
using UnityEngine.Profiling;

namespace Game.Planets {
	public class Planet: MonoBehaviour {
		[SerializeField] private TileGraph _graph;

		public event Action Tick;

		public TileGraph Graph => _graph;

		public void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				Debug.Log("Planet tick.");
				Profiler.BeginSample("Planet tick");
				Tick?.Invoke();
				Profiler.EndSample();
			}
		}

		public void Replace(TileFacade tile, TileFacade with) {
			var holder = tile.Holder;
			tile.Detach();
			with.AttachTo(holder);
			_graph.Replace(tile.Node, with.Node);
		}
	}
}