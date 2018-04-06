using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedPollen : MonoBehaviour {

	public bool HasPollen;
	public string PollenColor;
	public GameObject PlayerPollen;
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
		HasPollen = true;
		PollenColor = budPollen.transform.parent.tag;
		ColorPollen ();
		PlayerPollen.SetActive (true);
	}

	void ColorPollen() 
	{
		if (PollenColor == "Red") {_playerPollenSprite.color = Color.red;}
		if (PollenColor == "Blue") {_playerPollenSprite.color = Color.blue;}
		if (PollenColor == "Green") {_playerPollenSprite.color = Color.green;}
		if (PollenColor == "Yellow") {_playerPollenSprite.color = Color.yellow;}
	}

	public void DetachPollen() 
	{
		HasPollen = false;
		PlayerPollen.SetActive (false);
	}
}
