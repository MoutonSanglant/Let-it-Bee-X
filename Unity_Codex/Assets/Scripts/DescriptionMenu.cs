using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionMenu : MonoBehaviour 
{
	public Text Name;
	public Text Description;
	public RawImage ImageMain, ImageTop, ImageMiddle, ImageBottom;
	public CodexEntry Entry;

	void OnEnable() 
	{
		Entry.UnseenContent = false;
		Name.text = Entry.Name;
		Description.text = Entry.Description;
		ImageMain.texture = Entry.ImageMain;
		ImageTop.texture = Entry.ImageTop;
		ImageMiddle.texture = Entry.ImageMiddle;
		ImageBottom.texture = Entry.ImageBottom;
	}
}
