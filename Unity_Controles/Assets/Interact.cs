using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{

	public GameObject exclamationSprite;
	GameObject go;
	private DialogueTrigger dial;
	
	public Image img;

	// Use this for initialization
	void Start()
	{
        dial = GetComponent<DialogueTrigger>();
	}

	// Update is called once per frame
	void Update()
	{
		if (exclamationSprite.active)
		{
			if (Touch.TouchCount() > 0) // && Input.GetTouch(0).phase == TouchPhase.Began)
			{
				print(Touch.TouchCount());
			//	Debug.Log("TOUCHING");
				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Touch.GetPos()), Vector2.zero);
				if (hit)
				{
					if (hit.collider.CompareTag("Player") || hit.collider.name == "exclamationmark" || hit.collider.CompareTag("NPC"))
					{
						exclamationSprite.SetActive(false);
						dial.TriggerDialogue();
						Debug.Log("Touched " + hit.collider.name);
					}	
				}
			}
		}
	}

	public void ReloadSpriteOnEndDialog()
	{
		exclamationSprite.SetActive(true);
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		exclamationSprite.SetActive(true);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		exclamationSprite.SetActive(false);
	}
}