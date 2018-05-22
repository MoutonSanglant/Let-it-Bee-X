using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PagesMenu : MonoBehaviour 
{
	public CodexManager CodexManager;
	public MenuManager MenuManager;

	public GameObject EntriesDisplay, Panel;
	public Text SubtitleText;
	public CodexCategory Category;

	void OnEnable() 
	{
		CheckDatabase ();	
		SubtitleText.text = Category.Name;
	}

	void CheckDatabase() 
	{
		foreach (CodexEntry entry in CodexManager.CodexDatabase.EntryArray) 
		{
			if (entry.IsUnlock && entry.Category == Category.Category) { CreateEntryPanel (entry); }
		}
	}

	void CreateEntryPanel(CodexEntry entry) 
	{
		GameObject newPanel = Instantiate (Panel, EntriesDisplay.transform);
		Panel newPanelScript = newPanel.GetComponent<Panel> ();
		newPanelScript.CodexManager = CodexManager;
		newPanelScript.MenuManager = MenuManager;
		newPanelScript.Entry = entry;
	}

	void OnDisable() 
	{
		DestroyAllPages ();
	}

	void DestroyAllPages() 
	{
		foreach(Transform entry in EntriesDisplay.transform) 
		{
			Destroy (entry.gameObject);
		}
	}
}
