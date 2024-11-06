using Game.Services;
using UnityEngine;

namespace Game.Testing {
	[CreateAssetMenu(menuName = "Services/Test service")]
	public class TestService: GameService {
		[SerializeField] private string _text = "text";

		public override void Init(GameServices services) {
			Debug.Log($"Test service init. Text: {_text}");
		}
	}
}