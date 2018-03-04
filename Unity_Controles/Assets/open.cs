using UnityEngine;

using System.Collections;

public class open : MonoBehaviour
{

	private void OnCollisionEnter2D(Collision2D col) 
	{
		print(col.gameObject.name);
		if(col.gameObject.name == "Player")
		{
			foreach (Transform child in transform)
			{
				child.gameObject.SetActive(true);
			}
		}
	}
}