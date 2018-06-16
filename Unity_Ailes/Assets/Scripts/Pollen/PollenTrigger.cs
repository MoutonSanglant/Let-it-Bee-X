using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenTrigger : MonoBehaviour {

	public Bud Bud;
	public PollenSpawner PollenSpawner;

	private void OnTriggerEnter2D (Collider2D collider) 
	{
		PollenGrain _collidingGrain = collider.gameObject.GetComponent<PollenGrain> ();
		if (_collidingGrain  && _collidingGrain.GrainColor == Bud.PollenColor) 
		{
			Bud.EnablePlatforms ();
		}
	}
}
