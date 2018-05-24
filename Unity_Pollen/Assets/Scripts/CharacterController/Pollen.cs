using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PollenColor {Red, Blue, Yellow, Cyan};

public class Pollen : MonoBehaviour {

	public GameObject PlayerPollen;
	public PollenColor PlayerPollenColor;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.GetComponent<FlowerPollen>()) {
			SetPollenColor (collider.gameObject.GetComponent<FlowerPollen>());
			PlayerPollen.SetActive (true);
		}
	}

	void SetPollenColor(FlowerPollen _flowerPollen) {
		foreach(Transform pollen in PlayerPollen.transform) {
			SpriteRenderer pollenSprite = pollen.GetComponent<SpriteRenderer> ();
			if (_flowerPollen.PollenColor == PollenColor.Red){
				PlayerPollenColor = PollenColor.Red;
				pollenSprite.color = Color.red;
			} else if (_flowerPollen.PollenColor == PollenColor.Blue) {
				PlayerPollenColor = PollenColor.Blue;
				pollenSprite.color = Color.blue;
			} else if (_flowerPollen.PollenColor == PollenColor.Yellow) {
				PlayerPollenColor = PollenColor.Yellow;
				pollenSprite.color = Color.yellow;
			} else if (_flowerPollen.PollenColor == PollenColor.Cyan) {
				PlayerPollenColor = PollenColor.Cyan;
				pollenSprite.color = Color.cyan;
			}
		}
	}
}
