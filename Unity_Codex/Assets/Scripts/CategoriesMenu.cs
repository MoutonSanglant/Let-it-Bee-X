using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoriesMenu : MonoBehaviour 
{
	public GameObject CategoriesDisplay, Panel;
	public MenuManager MenuManager;
	public CodexManager CodexManager;
	public Text SubTitleText;

	void OnEnable() 
	{
		CheckDatabase ();
		SubTitleText.text = CodexManager.CodexDatabase.SubTitle;
	}

	//Check la base de donnée et creer les panel necessaires si unlock
	void CheckDatabase() 
	{
		foreach(Category category in CodexManager.CodexDatabase.CategoryArray) 
		{
			if (category.IsUnlock) { CreateCategoryPanel (category); }
		}
	}

	void CreateCategoryPanel(Category category) 
	{
		GameObject newPanel = Instantiate (Panel, CategoriesDisplay.transform);
		CategoryPanel newPanelScript = newPanel.GetComponent<CategoryPanel> ();
		newPanelScript.MenuManager = MenuManager;
		newPanelScript.CodexManager = CodexManager;
		newPanelScript.Category = category;
		newPanelScript.IsCategory = true;
		category.UnseenContent = false;
		CheckUnseenContent (category);
		if (category.UnseenContent) { newPanelScript.UnseenContentPanel.SetActive (true); }
	}

	void CheckUnseenContent(Category category) {
		foreach(CodexEntry entry in CodexManager.CodexDatabase.EntryArray) {
			if (entry.Cat == category.Cat && entry.UnseenContent) {
				category.UnseenContent = true;
			}
		}
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
