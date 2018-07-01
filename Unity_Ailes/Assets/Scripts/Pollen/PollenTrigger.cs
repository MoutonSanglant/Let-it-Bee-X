using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenTrigger : MonoBehaviour 
{

	public Bud Bud;

	private void OnTriggerEnter2D (Collider2D collider) 
	{
		PollenGrain _grain = collider.gameObject.GetComponent<PollenGrain> ();
		if (_grain  && _grain.GrainColor == Bud.PollenColor) 
		{
			Destroy (_grain.gameObject);
			Bud.EnablePlatforms ();
		}
	}
}
