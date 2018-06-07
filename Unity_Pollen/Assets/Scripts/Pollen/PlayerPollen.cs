using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PollenColor{Yellow, Green, Cyan, Magenta};

public class PlayerPollen : MonoBehaviour {

	public GameObject PollenContainer, GrainSprite;
	public PollenColor PollenColor;
	public int GrainCount;
		
	private void OnCollisionEnter2D (Collision2D collision) {
		PollenGrain _collidingGrain = collision.gameObject.GetComponent<PollenGrain> ();
		if (_collidingGrain) {
			Destroy (_collidingGrain.gameObject);
			if (_collidingGrain.GrainColor != PollenColor) {
				DestroyAllGrain ();
			}
			PollenColor = _collidingGrain.GrainColor;
			SpawnNewGrain (_collidingGrain.GrainColor);
		}
	}

	private void SpawnNewGrain(PollenColor newGrainColor) {
		foreach(Transform child in PollenContainer.transform) {
			if (child.childCount == 0) {
				GrainCount++;
				GameObject _newGrain = Instantiate (GrainSprite, child.position, Quaternion.identity, child);
				SetNewGrainColor (_newGrain, newGrainColor);
				break;
			}
		}
	}

	private void SetNewGrainColor(GameObject newGrain, PollenColor pollenColor) {
		SpriteRenderer _sprite = newGrain.GetComponent<SpriteRenderer> ();
		if (pollenColor == PollenColor.Yellow) {
			_sprite.color = Color.yellow;
		} else if (pollenColor == PollenColor.Green) {
			_sprite.color = Color.green;
		} else if (pollenColor == PollenColor.Cyan) {
			_sprite.color = Color.cyan;
		} else if (pollenColor == PollenColor.Magenta) {
			_sprite.color = Color.magenta;
		}
	}

	private void DestroyAllGrain() {
		GrainCount = 0;
		foreach(Transform child in PollenContainer.transform) {
			if (child.childCount != 0) {
				Destroy (child.GetChild (0).gameObject);
			}
		}
	}
}
