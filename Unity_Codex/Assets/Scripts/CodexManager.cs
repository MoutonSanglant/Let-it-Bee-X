using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodexManager : MonoBehaviour 
{
	public CodexDatabase CodexDatabase;
	public Text TitleText;

	void Start() 
	{
		TitleText.text = CodexDatabase.Title;
	}

	//Fonction pour debloquer un entrée
	public void UnlockEntry(int entryId) {
		foreach(CodexEntry entry in CodexDatabase.EntryArray) {
			if (entryId == entry.Id) {
				entry.IsUnlock = true;
				entry.UnseenContent = true;
				foreach(Category category in CodexDatabase.CategoryArray) {
					if (category.Cat == entry.Cat) {
						category.IsUnlock = true;
					}
				}
			}
		}	
	}

	//Utile uniquement pour l'éditeur
	void OnApplicationQuit() 
	{
		foreach(CodexEntry entry in CodexDatabase.EntryArray) {
			entry.IsUnlock = false;
			entry.UnseenContent = false;
		}
	}
}
