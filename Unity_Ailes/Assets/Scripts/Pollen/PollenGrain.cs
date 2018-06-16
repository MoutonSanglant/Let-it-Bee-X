using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenGrain : MonoBehaviour {

	public PollenColor GrainColor;
	public float AttachSpeed;
	public float GravityScale;
	[HideInInspector]
	public bool IsMovingTowardPlayer, AttachedToPlayer;

	private SpriteRenderer _sprite;
	private GameObject _collider;
	private Rigidbody2D _rig;

	void Start() 
	{
		_rig = GetComponent<Rigidbody2D> ();
		_sprite = GetComponent<SpriteRenderer> ();
		_collider = transform.GetChild (0).gameObject;
		transform.hasChanged = false;
		SetColor();
	}

	void Update() 
	{
		if (AttachedToPlayer) 
		{
			if (IsMovingTowardPlayer) 
			{
				MoveToPlayer (); 
			} else 
			{
				StayOnPlayer ();
			}
		}
		else if (transform.hasChanged && !AttachedToPlayer) 
		{
			_rig.gravityScale = GravityScale;
			transform.parent = GameObject.Find("PollenManager").transform;
		}
	}

	private void MoveToPlayer() 
	{
		gameObject.tag = "Static";
		_collider.layer = 11;
		float _moveSpeed = AttachSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, transform.parent.position, _moveSpeed);
		if (transform.position == transform.parent.position) 
		{
			IsMovingTowardPlayer = false; 
		}
	}

	private void StayOnPlayer() 
	{
		transform.position = transform.parent.position;
	}

	private void SetColor() 
	{
		if (GrainColor == PollenColor.Yellow) { _sprite.color = Color.yellow; }
		else if (GrainColor == PollenColor.Green) { _sprite.color = Color.green; }
		else if (GrainColor == PollenColor.Cyan) { _sprite.color = Color.cyan; }
		else if (GrainColor == PollenColor.Magenta) { _sprite.color = Color.magenta; }
	}
}
