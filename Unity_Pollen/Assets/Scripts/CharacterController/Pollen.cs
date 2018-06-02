using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PollenColor {Red, Blue, Yellow, Cyan};

public class Pollen : MonoBehaviour {

	public GameObject AttachedPollen;
	public PollenColor PollenColor;
	public bool hasPollen;

	public void DisablePollen() {
		hasPollen = false;
		AttachedPollen.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		FlowerPollen _flower = collider.gameObject.GetComponent<FlowerPollen> ();
		if (_flower) {
			SetPollenColor (_flower);
			hasPollen = true;
			AttachedPollen.SetActive (true);
		}
	}

	void SetPollenColor(FlowerPollen _flower) {
		foreach(Transform pollen in AttachedPollen.transform) {
			SpriteRenderer pollenSprite = pollen.GetComponent<SpriteRenderer> ();
			if (_flower.PollenColor == PollenColor.Red){
				PollenColor = PollenColor.Red;
				pollenSprite.color = Color.red;
			} else if (_flower.PollenColor == PollenColor.Blue) {
				PollenColor = PollenColor.Blue;
				pollenSprite.color = Color.blue;
			} else if (_flower.PollenColor == PollenColor.Yellow) {
				PollenColor = PollenColor.Yellow;
				pollenSprite.color = Color.yellow;
			} else if (_flower.PollenColor == PollenColor.Cyan) {
				PollenColor = PollenColor.Cyan;
				pollenSprite.color = Color.cyan;
			}
		}
	}
}
