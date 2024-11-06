using UnityEngine;

namespace Game.Services {
	public abstract class GameService: ScriptableObject, IGameService { 
		public abstract void Init(GameServices services);
	}
}