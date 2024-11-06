using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Services {
	public class GameServices {
		private Dictionary<Type, IGameService> _services = new Dictionary<Type, IGameService>();

		public event Action AllServicesInitialized;

		#region Init
		public static GameServices Instance { get; private set; }
		public const string Path = "Services";

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void InitializeOnLoad() {
			Instance = new GameServices();
			Instance.LoadServicesFromFolder();
		}
		private void LoadServicesFromFolder() {
			var services = Resources.LoadAll<GameService>(Path);
			foreach (var service in services) {
				service.Init(this);
				Register(service);
			}
			Debug.Log($"Loaded {services.Length} services.");
			AllServicesInitialized?.Invoke();
		}
		#endregion

		public T Get<T>() where T: IGameService {
			return (T)_services[typeof(T)];
		}
		public bool TryGet<T>(out T service) where T: IGameService {
			if (_services.ContainsKey(typeof(T))) {
				service = (T)_services[typeof(T)];
				return true;
			}
			service = default;
			return false;
		}
		public void Register(IGameService service) { 
			var type = service.GetType();
			if (_services.ContainsKey(type)) {
				Debug.LogError($"Service '{type}' already loaded.");
				return;
			}
			_services.Add(type, service);
		}

		public static T GetService<T>() where T: IGameService => Instance.Get<T>();
	}
}