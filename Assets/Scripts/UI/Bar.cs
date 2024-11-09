﻿using UnityEngine;
using UnityEngine.UI;

namespace Game.UI {
	public class Bar: MonoBehaviour {
		[SerializeField] private Image _fill;

		public void SetFill(float value) {
			_fill.fillAmount = Mathf.Clamp01(value);
		}
	}
}