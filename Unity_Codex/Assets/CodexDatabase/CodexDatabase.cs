using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CategoryEnum {A,B,C};

[CreateAssetMenu(fileName = "CodexDatabase", menuName = "CodexDatabase")]
public class CodexDatabase : ScriptableObject
{
	public string Title, SubTitle;
	public Category[] CategoryArray;
	public CodexEntry[] EntryArray;
}

[System.Serializable]
public class Category 
{
	public string Name;
	public CategoryEnum Cat;
	public bool IsUnlock;
	public bool UnseenContent;
	public Texture2D Thumbnail;
	public CodexEntry[] PageArray;
}