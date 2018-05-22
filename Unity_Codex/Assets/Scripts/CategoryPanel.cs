using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryPanel : MonoBehaviour 
{
	public Category Category;
	public CodexEntry Entry;
	public Text NameText;
	public Button PanelButton;
	public MenuManager MenuManager;
	public CodexManager CodexManager;
	public RawImage Thumbnail;
	public GameObject UnseenContentPanel;
	public bool IsCategory;

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
		PanelButton.onClick.AddListener (() => MenuManager.GoToPagesMenu (Category));
		foreach(CodexEntry entry in CodexManager.CodexDatabase.EntryArray) 
		{
			if (entry.Cat == Category.Cat && entry.UnseenContent) { Category.UnseenContent = true; }
		}
	}

	void ApplyEntryData() 
	{
		NameText.text = Entry.Name;
		Thumbnail.texture = Entry.ImageMain;
		PanelButton.onClick.AddListener (() => MenuManager.GoToDescriptionMenu (Entry));
	}
}
