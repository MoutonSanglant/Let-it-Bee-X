using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodexManager : MonoBehaviour 
{
	public CodexDatabase CodexDatabase;
	public Text TitleText;

	void Start() 
	{
		TitleText.text = CodexDatabase.Title;
	}

	public void Unlock(string pageName) 
	{
		foreach(Category category in CodexDatabase.CategoryArray) 
		{
			foreach(Page page in category.PageArray) 
			{
				if (pageName == page.Name) 
				{
					category.IsUnlock = true;
					category.UnseenContent = true;
					page.IsUnlock = true;
					page.UnseenContent = true;
				}
			}
		}
	}



	//Utile uniquement pour l'éditeur
	void OnApplicationQuit() 
	{
		foreach(Category category in CodexDatabase.CategoryArray) 
		{
			foreach (Page page in category.PageArray) 
			{
				category.IsUnlock = false;
				page.IsUnlock = false;
			}
		}
	}
}
