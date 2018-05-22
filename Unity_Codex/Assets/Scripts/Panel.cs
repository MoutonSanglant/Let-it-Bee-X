using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour 
{
	public CodexManager CodexManager;
	public MenuManager MenuManager;
	public CodexCategory Category;
	public bool IsCategory;
	public CodexEntry Entry;

	public Text NameText;
	public Button PanelButton;
	public RawImage Thumbnail;
	public GameObject UnseenContentPanel;

	void Start() 
	{
		PanelButton = GetComponent<Button> ();
		if (IsCategory) 
		{
			ApplyCategoryData ();
		} 
		else { ApplyEntryData (); }
	}

	void ApplyCategoryData() 
	{
		Category.UnseenContent = false;
		NameText.text = Category.Name;
		Thumbnail.texture = Category.Thumbnail;
		CheckUnseenContent ();
		if (Category.UnseenContent) { UnseenContentPanel.SetActive (true); }
		PanelButton.onClick.AddListener (() => MenuManager.GoToEntriesMenu (Category));
	}

	void CheckUnseenContent() 
	{
		Category.UnseenContent = false;
		foreach(CodexEntry entry in CodexManager.CodexDatabase.EntryArray) 
		{
			if (entry.Category == Category.Category && entry.UnseenContent) 
			{
				Category.UnseenContent = true;
			}
		}
	}

	void ApplyEntryData() 
	{
		NameText.text = Entry.Name;
		Thumbnail.texture = Entry.ImageMain;
		if (Entry.UnseenContent) { UnseenContentPanel.SetActive (true); }
		PanelButton.onClick.AddListener (() => MenuManager.GoToDescriptionMenu (Entry));
	}
}
