using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour 
{

	public CodexManager CodexManager;
	public GameObject CategoriesMenu, EntriesMenu, DescriptionMenu;

	void OnEnable() 
	{
		Time.timeScale = 0;
		GoToCategoriesMenu ();
	}

	void OnDisable() 
	{
		Time.timeScale = 1;
	}

	public void GoToCategoriesMenu() 
	{
		EntriesMenu.SetActive (false);
		DescriptionMenu.SetActive (false);
		CategoriesMenu.SetActive (true);
	}

	public void GoToEntriesMenu (CodexCategory category) 
	{
		EntriesMenu.GetComponent<PagesMenu> ().Category = category;
		CategoriesMenu.SetActive (false);
		EntriesMenu.SetActive (true);
	}

	public void GoToDescriptionMenu(CodexEntry entry) 
	{
		DescriptionMenu.GetComponent<DescriptionMenu> ().Entry = entry;
		EntriesMenu.SetActive (false);
		DescriptionMenu.SetActive (true);
	}
}
