using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedPollen : MonoBehaviour {

	public bool HasPollen;
	public GameObject PlayerPollen;
	public PollenColor AttachedPollenColor;
	private SpriteRenderer _playerPollenSprite;

	void Start() 
	{
		_playerPollenSprite = PlayerPollen.GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D (Collider2D collider) 
	{
		if (collider.gameObject.name == "Pollen") {
			AttachPollen (collider);
		}
	}

	void AttachPollen (Collider2D budPollen) 
	{
		Bourgeon bud = budPollen.GetComponentInParent<Bourgeon> ();
		HasPollen = true;
		AttachedPollenColor = bud.BudColor;
		ColorPollen ();
		PlayerPollen.SetActive (true);
	}

	void ColorPollen() 
	{
		if (AttachedPollenColor == PollenColor.Red) {_playerPollenSprite.color = Color.red;}
		if (AttachedPollenColor == PollenColor.Blue) {_playerPollenSprite.color = Color.blue;}
		if (AttachedPollenColor == PollenColor.Green) {_playerPollenSprite.color = Color.green;}
		if (AttachedPollenColor == PollenColor.Yellow) {_playerPollenSprite.color = Color.yellow;}
	}

	public void DetachPollen() 
	{
		HasPollen = false;
		PlayerPollen.SetActive (false);
	}
}
