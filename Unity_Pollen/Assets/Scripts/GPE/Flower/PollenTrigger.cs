using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenTrigger : MonoBehaviour {

	public Bud Bud;
	public FlowerPollen FlowerPollen;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.GetComponent<Pollen> ()) {
			Pollen _player = collider.gameObject.GetComponent<Pollen> ();
			if (_player.hasPollen && _player.PollenColor == FlowerPollen.PollenColor) {
				Bud.EnablePlatforms ();
				_player.DisablePollen ();
				gameObject.SetActive (false);
			}
		}
	}

	public void EnablePlatforms() {
		Bud.EnablePlatforms ();
		gameObject.SetActive (false);
	}
}
