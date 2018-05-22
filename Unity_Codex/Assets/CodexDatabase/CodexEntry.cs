using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CodexEntry", menuName = "CodexEntry")]
public class CodexEntry : ScriptableObject {

	public string Name;
	public int Id;
	public CategoryEnum Cat;
	public bool IsUnlock;
	public bool UnseenContent;
	public string Description;
	public Texture2D ImageMain, ImageTop, ImageMiddle, ImageBottom;
}
