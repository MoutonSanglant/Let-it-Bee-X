using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PollenColor{Yellow, Green, Cyan, Magenta};

public class PlayerPollen : MonoBehaviour {

	public GameObject PollenContainer;
	public PollenColor PollenColor;
	public int GrainCount;

	private Transform _availableAnchor;
		
	private void OnTriggerEnter2D (Collider2D collider)
	{
		PollenGrain _collidingGrain = collider.gameObject.GetComponent<PollenGrain> ();
		PollenTrigger _pollenTrigger = collider.gameObject.GetComponent<PollenTrigger> ();
		if (_collidingGrain) {
			if (_collidingGrain.GrainColor != PollenColor) {
				DestroyAllGrain ();
			}
			if (!_collidingGrain.AttachedToPlayer && GrainCount < PollenContainer.transform.childCount) {
				AttachGrainToPlayer (_collidingGrain);
			}
		}
		if (_pollenTrigger) {
			DestroyOneGrain ();
		}
	}

	private void AttachGrainToPlayer(PollenGrain grain) 
	{
		GrainCount++;
		PollenColor = grain.GrainColor;
		SeekAvailableAnchor ();
		grain.transform.parent = _availableAnchor;
		grain.AttachedToPlayer = true;
		grain.IsMovingTowardPlayer = true;
	}

	private void SeekAvailableAnchor() 
	{
		foreach(Transform child in PollenContainer.transform) 
		{
			if (child.childCount == 0) { _availableAnchor = child; }
		}
	}

	private void DestroyOneGrain() 
	{
		GrainCount--;
		foreach (Transform child in PollenContainer.transform) 
		{
			if (child.childCount != 0) 
			{
				Destroy (child.GetChild (0).gameObject);
				break;
			}
		}
	}

	private void DestroyAllGrain() 
	{
		GrainCount = 0;
		foreach(Transform child in PollenContainer.transform) 
		{
			if (child.childCount != 0) { Destroy (child.GetChild (0).gameObject); }
		}
	}
}
