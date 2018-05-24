using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenTrigger : MonoBehaviour {

	public Bud Bud;
	public FlowerPollen FlowerPollen;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.GetComponent<Pollen> ()) {
			Pollen _playerPollen = collider.gameObject.GetComponent<Pollen> ();
			if (_playerPollen.PlayerPollenColor == FlowerPollen.PollenColor) {
				Bud.EnablePlatforms ();
				gameObject.SetActive (false);
			}
		}
	}
}
