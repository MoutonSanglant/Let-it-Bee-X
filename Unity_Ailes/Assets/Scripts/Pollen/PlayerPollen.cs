using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PollenColor{None, Yellow, Green, Cyan, Magenta};

public class PlayerPollen : MonoBehaviour 
{

	public GameObject PollenContainer;
	public CircleCollider2D DetachTriggerArea;
	[HideInInspector]
	public PollenColor PlayerPollenColor;
	[HideInInspector]
	public  static int GrainCount;

	private Transform _availableAnchor;


	private void Update() 
	{
		if (Input.touchCount != 0) 
		{
			Touch _touch = Input.GetTouch (0);
			Vector3 _touchPos = Camera.main.ScreenToWorldPoint (_touch.position);
			if (_touch.tapCount == 2 && DetachTriggerArea.OverlapPoint (_touchPos)) 
			{
				DetachAllGrain ();
			}
		} else if (Input.GetMouseButtonDown(2)) {
			DetachAllGrain ();
		}
	}

	private void OnTriggerEnter2D (Collider2D collider)
	{
		PollenGrain _grain = collider.gameObject.GetComponent<PollenGrain> ();
		if (_grain) 
		{
			if (!_grain.AttachedToPlayer) 
			{
				if (GrainCount == 0 || _grain.GrainColor == PlayerPollenColor && GrainCount < PollenContainer.transform.childCount) 
				{
					AttachGrainToPlayer (_grain);
				}
			}
		}
	}

	private void AttachGrainToPlayer(PollenGrain grain) 
	{
		GrainCount++;
		SeekAvailableAnchor ();
		PlayerPollenColor = grain.GrainColor;
		grain.transform.parent = _availableAnchor;
		grain.AttachedToPlayer = true;
		grain.MovingTowardPlayer = true;
	}

	private void SeekAvailableAnchor() 
	{
		foreach(Transform child in PollenContainer.transform) 
		{
			if (child.childCount == 0) 
			{
				_availableAnchor = child;
			}
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

	private void DetachAllGrain() 
	{
		foreach(Transform child in PollenContainer.transform) 
		{
			if (child.childCount != 0) 
			{
				PollenGrain _grain = child.GetComponentInChildren<PollenGrain> ();
				_grain.AttachedToPlayer = false;
				_grain.tag = "Movable";
			}
		}
		PlayerPollenColor = PollenColor.None;
		GrainCount = 0;
	}
}
