using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenGrain : MonoBehaviour {

	public PollenColor GrainColor;
	private SpriteRenderer _sprite;

	void Start() {
		_sprite = GetComponent<SpriteRenderer> ();
		SetColor();
	}

	private void SetColor() {
		if (GrainColor == PollenColor.Yellow) {
			_sprite.color = Color.yellow;
		} else if (GrainColor == PollenColor.Green) {
			_sprite.color = Color.green;
		} else if (GrainColor == PollenColor.Cyan) {
			_sprite.color = Color.cyan;
		} else if (GrainColor == PollenColor.Magenta) {
			_sprite.color = Color.magenta;
		}
	}
}
