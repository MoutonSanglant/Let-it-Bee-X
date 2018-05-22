using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoriesMenu : MonoBehaviour 
{
	public CodexManager CodexManager;
	public MenuManager MenuManager;

	public GameObject CategoriesDisplay, Panel;
	public Text SubTitleText;

	void OnEnable() 
	{
		CheckDatabase();
		SubTitleText.text = CodexManager.CodexDatabase.SubTitle;
	}
		
	void CheckDatabase() 
	{
		foreach(CodexCategory category in CodexManager.CodexDatabase.CategoryArray) 
		{
			if (category.IsUnlock) { CreateCategoryPanel (category); }
		}
	}

	void CreateCategoryPanel(CodexCategory category) 
	{
		GameObject newPanel = Instantiate (Panel, CategoriesDisplay.transform);
		Panel newPanelScript = newPanel.GetComponent<Panel> ();
		newPanelScript.CodexManager = CodexManager;
		newPanelScript.MenuManager = MenuManager;
		newPanelScript.IsCategory = true;
		newPanelScript.Category = category;
	}

	void OnDisable() 
	{
		DestroyAllCategories ();
	}

	void DestroyAllCategories() 
	{
		foreach(Transform category in CategoriesDisplay.transform) 
		{
			Destroy (category.gameObject);
		}
	}
}
