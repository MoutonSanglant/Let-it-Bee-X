using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

	public float PushForce;
	public float MaxDist, MinDist;

	[HideInInspector]
	public Vector3 PushDirection;
	[HideInInspector]
	public float TouchDist;

	private BoxCollider2D _col;
	private float _pushLength;

	void Awake() 
	{
		_col = GetComponent<BoxCollider2D> ();
	}

	private void OnTriggerStay2D (Collider2D collider) 
	{
		float _colDist = Vector3.Magnitude (collider.transform.position - transform.parent.position);
		if (collider.tag == "Movable" &&  _colDist <= _pushLength) 
		{
			float _colliderDist = Vector3.Magnitude (collider.transform.position - transform.parent.position);
			Rigidbody2D _colliderRig = collider.gameObject.GetComponent<Rigidbody2D> ();
			_colliderRig.AddForce (PushDirection.normalized * PushForce);
		}
	}

	void Update() 
	{
		_pushLength = Mathf.Clamp (TouchDist, MinDist, MaxDist);
		Debug.Log ("TouchDist : " + TouchDist + "\nPushLength : " + _pushLength + " PushDirection : " + PushDirection.normalized);
	}
}
