using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CodexDatabase", menuName = "CodexDatabase")]
public class CodexDatabase : ScriptableObject
{
	public Category[] CategoryArray;
	public string Title, SubTitle;
}

[System.Serializable]
public class Category 
{
	public string Name;
	public bool IsUnlock;
	public bool UnseenContent;
	public Texture2D Thumbnail;
	public Page[] PageArray;
}

[System.Serializable]
public class Page 
{
	public string Name;
	public bool IsUnlock;
	public bool UnseenContent;
	public string Description;
	public Texture2D ImageMain, ImageTop, ImageMiddle, ImageBottom;
}