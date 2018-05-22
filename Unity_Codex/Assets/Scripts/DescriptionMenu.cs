using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionMenu : MonoBehaviour 
{
	public Text Name;
	public Text Description;
	public RawImage ImageMain, ImageTop, ImageMiddle, ImageBottom;
	public CodexEntry Page;

	void OnEnable() 
	{
		Page.UnseenContent = false;
		Name.text = Page.Name;
		Description.text = Page.Description;
		ImageMain.texture = Page.ImageMain;
		ImageTop.texture = Page.ImageTop;
		ImageMiddle.texture = Page.ImageMiddle;
		ImageBottom.texture = Page.ImageBottom;
	}
}
