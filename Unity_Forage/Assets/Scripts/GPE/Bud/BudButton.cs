using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BudButton : MonoBehaviour
{
	public GameObject PopUp;
	public bool PlayerInside
	{
		get
		{
			return _playerInside;
		}
	}
	bool _playerInside;
	Bud _parent;

	private void Awake()
	{
		_parent = GetComponentInParent<Bud>();
		_playerInside = false;
	}

	void PlayerComesIn()
	{
		_playerInside = true;
		if (!_parent.IsOpen)
			PopUp.SetActive(true);
	}

	void PlayerLeaves()
	{
		_playerInside = false;
		if (PopUp.activeSelf)
			DisablePopUp();
	}

	public void DisablePopUp()
	{
		PopUp.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
			PlayerComesIn();
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
			PlayerLeaves();
	}

	private void OnMouseDown()
	{
		print("salut");
		if (!_parent.IsOpen && PlayerInside)
			_parent.EnablePlatforms();
	}
}
