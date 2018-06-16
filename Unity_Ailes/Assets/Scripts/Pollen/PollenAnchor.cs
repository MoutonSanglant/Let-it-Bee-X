using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenAnchor : MonoBehaviour {

	public float GizmosRadius;
	public bool GrainSpawned;

	void OnDrawGizmos() 
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, GizmosRadius);
	}
}
