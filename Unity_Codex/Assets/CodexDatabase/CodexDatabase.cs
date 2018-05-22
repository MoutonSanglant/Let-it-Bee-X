using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CategoryEnum {A,B,C,D,E,F,G,H,I,J,K,L};

[CreateAssetMenu(fileName = "CodexDatabase", menuName = "Codex/Codex Database")]
public class CodexDatabase : ScriptableObject
{
	public string Title, SubTitle;
	public CodexCategory[] CategoryArray;
	public CodexEntry[] EntryArray;
}

[System.Serializable]
public class CodexCategory 
{
	public string Name;
	public CategoryEnum Category;
	public bool IsUnlock;
	public bool UnseenContent;
	public Texture2D Thumbnail;
}