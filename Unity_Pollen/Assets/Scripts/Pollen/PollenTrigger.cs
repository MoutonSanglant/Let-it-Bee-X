using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenTrigger : MonoBehaviour {

	public Bud Bud;
	public PollenSpawner PollenSpawner;

	private void OnTriggerEnter2D (Collider2D collider) 
	{
		PlayerPollen _player = collider.gameObject.GetComponent<PlayerPollen> ();
		if (_player) 
		{
			if (_player.GrainCount != 0 && _player.PollenColor == PollenSpawner.PollenColor) 
			{ 
				Bud.EnablePlatforms (); 
			}
		}
	}
}
