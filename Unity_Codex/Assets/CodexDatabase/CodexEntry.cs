using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CodexEntry", menuName = "Codex/Codex Entry")]
public class CodexEntry : ScriptableObject 
{
	public string Name;
	public int Id;
	public CategoryEnum Category;
	public bool IsUnlock;
	public bool UnseenContent;
	[TextArea]
	public string Description;
	public Texture2D ImageMain, ImageTop, ImageMiddle, ImageBottom;
}
