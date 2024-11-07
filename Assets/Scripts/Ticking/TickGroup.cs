using System;
using UnityEngine;

namespace Game.Ticking {
	[CreateAssetMenu(menuName = "Ticking/TickGroup")]
	public class TickGroup: ScriptableObject {
		public event Action Tick;

		public virtual void OnTick() { 
			Tick?.Invoke();
		}
	}
}