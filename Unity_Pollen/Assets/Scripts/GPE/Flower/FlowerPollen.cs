using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPollen : MonoBehaviour {

	public PollenColor PollenColor;

	void Awake() {
		SetColor ();
	}
		
	void SetColor() {
		foreach(Transform pollen in transform) {
			SpriteRenderer pollenSprite = pollen.gameObject.GetComponent<SpriteRenderer> ();
			if (PollenColor == PollenColor.Red){
				pollenSprite.color = Color.red;
			} else if (PollenColor == PollenColor.Blue) {
				pollenSprite.color = Color.blue;
			} else if (PollenColor == PollenColor.Yellow) {
				pollenSprite.color = Color.yellow;
			} else if (PollenColor == PollenColor.Cyan) {
				pollenSprite.color = Color.cyan;
			}
		}
	}
}
