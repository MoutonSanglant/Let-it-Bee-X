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
		
	public void UnlockEntry(int entryId) 
	{
		foreach(CodexEntry entry in CodexDatabase.EntryArray) 
		{
			if (entryId == entry.Id && !entry.IsUnlock) 
			{
				entry.IsUnlock = true;
				entry.UnseenContent = true;
				foreach(CodexCategory category in CodexDatabase.CategoryArray) 
				{
					if (category.Category == entry.Category) { category.IsUnlock = true; }
				}
			}
		}	
	}
}
