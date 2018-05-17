using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryPanel : MonoBehaviour 
{
	public Category Category;
	public Page Page;
	public Text NameText;
	public Button PanelButton;
	public MenuManager MenuManager;
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
		else { ApplyPageData (); }
	}

	void ApplyCategoryData() 
	{
		Category.UnseenContent = false;
		NameText.text = Category.Name;
		Thumbnail.texture = Category.Thumbnail;
		PanelButton.onClick.AddListener (() => MenuManager.GoToPagesMenu (Category));
		foreach(Page pages in Category.PageArray) 
		{
			if (pages.UnseenContent) { Category.UnseenContent = true; }
		}
		CheckUnseenContent ();
	}

	void ApplyPageData() 
	{
		NameText.text = Page.Name;
		Thumbnail.texture = Page.ImageMain;
		PanelButton.onClick.AddListener (() => MenuManager.GoToDescriptionMenu (Page));
		CheckUnseenContent ();
	}

	void CheckUnseenContent() {
		if (Category.UnseenContent || Page.UnseenContent) 
		{ 
			UnseenContentPanel.SetActive (true); 
		} 
		else { UnseenContentPanel.SetActive (false); }
	}
}
