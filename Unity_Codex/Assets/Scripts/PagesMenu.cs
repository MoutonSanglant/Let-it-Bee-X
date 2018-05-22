using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PagesMenu : MonoBehaviour 
{
	public GameObject PagesDisplay, Panel;
	public MenuManager MenuManager;
	public CodexManager CodexManager;
	public Text SubtitleText;
	public Category Category;

	void OnEnable() 
	{
		CheckDatabase ();	
		SubtitleText.text = Category.Name;
	}

	//Check la base de donnée et creer les panel necessaires si unlock
	void CheckDatabase() 
	{
		foreach (CodexEntry entry in CodexManager.CodexDatabase.EntryArray) 
		{
			if (entry.IsUnlock && entry.Cat == Category.Cat) { CreateEntryPanel (entry); }
		}
	}

	void CreateEntryPanel(CodexEntry entry) 
	{
		GameObject newPanel = Instantiate (Panel, PagesDisplay.transform);
		CategoryPanel newPanelScript = newPanel.GetComponent<CategoryPanel> ();
		newPanelScript.MenuManager = MenuManager;
		newPanelScript.CodexManager = CodexManager;
		newPanelScript.Entry = entry;
		if (entry.UnseenContent) { newPanelScript.UnseenContentPanel.SetActive (true); }
	}

	void OnDisable() 
	{
		DestroyAllPages ();
	}

	void DestroyAllPages() 
	{
		foreach(Transform entry in PagesDisplay.transform) 
		{
			Destroy (entry.gameObject);
		}
	}
}
