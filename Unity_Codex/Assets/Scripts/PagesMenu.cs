using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PagesMenu : MonoBehaviour 
{
	public GameObject PagesDisplay, Panel;
	public MenuManager MenuManager;
	public Text SubtitleText;
	public Category Category;

	void OnEnable() 
	{
		CheckDatabase ();	
		SubtitleText.text = Category.Name;
	}

	void CheckDatabase() 
	{
		foreach (Page page in Category.PageArray) 
		{
			if (page.IsUnlock) { CreatePagePanel (page); }
		}
	}

	void CreatePagePanel(Page page) 
	{
		GameObject newPanel = Instantiate (Panel, PagesDisplay.transform);
		CategoryPanel newPanelScript = newPanel.GetComponent<CategoryPanel> ();
		newPanelScript.MenuManager = MenuManager;
		newPanelScript.Page = page;
		if (page.UnseenContent) { newPanelScript.UnseenContentPanel.SetActive (true); }
	}

	void OnDisable() 
	{
		DestroyAllPages ();
	}

	void DestroyAllPages() 
	{
		foreach(Transform page in PagesDisplay.transform) 
		{
			Destroy (page.gameObject);
		}
	}
}
