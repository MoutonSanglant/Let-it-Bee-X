using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour 
{

	public CodexManager CodexManager;
	public GameObject CategoriesMenu, PagesMenu, DescriptionMenu;

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
		PagesMenu.SetActive (false);
		DescriptionMenu.SetActive (false);
		CategoriesMenu.SetActive (true);
	}

	public void GoToPagesMenu (Category category) 
	{
		PagesMenu.GetComponent<PagesMenu> ().Category = category;
		CategoriesMenu.SetActive (false);
		PagesMenu.SetActive (true);
	}

	public void GoToDescriptionMenu(Page page) 
	{
		DescriptionMenu.GetComponent<DescriptionMenu> ().Page = page;
		PagesMenu.SetActive (false);
		DescriptionMenu.SetActive (true);
	}
}
