using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenGrain : MonoBehaviour {

	public PollenColor GrainColor;
	public Transform GrainAnchor;
	public bool IsMovingTowardPlayer, AttachedToPlayer;
	public float AttachSpeed;

	private SpriteRenderer _sprite;
	private GameObject _collider;

	void Start() 
	{
		_sprite = GetComponent<SpriteRenderer> ();
		_collider = transform.GetChild (0).gameObject;
		SetColor();
	}

	void Update() 
	{
		if (AttachedToPlayer)
		{
			_collider.layer = 11;
			if (IsMovingTowardPlayer) { MoveToPlayer (); } 
			else { transform.position = transform.parent.position; }
		}
	}

	private void MoveToPlayer() 
	{
		float _moveSpeed = AttachSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, transform.parent.position, _moveSpeed);
		if (transform.position == transform.parent.position) { IsMovingTowardPlayer = false; }
	}

	private void SetColor() 
	{
		if (GrainColor == PollenColor.Yellow) { _sprite.color = Color.yellow; }
		else if (GrainColor == PollenColor.Green) { _sprite.color = Color.green; }
		else if (GrainColor == PollenColor.Cyan) { _sprite.color = Color.cyan; }
		else if (GrainColor == PollenColor.Magenta) { _sprite.color = Color.magenta; }
	}
}
