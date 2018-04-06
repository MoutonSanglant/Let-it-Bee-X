using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenDetector : MonoBehaviour {

	public Bourgeon bourgeon;

	void OnTriggerEnter2D (Collider2D collider) 
	{
		bourgeon.PullTrigger (collider);
	}
}
