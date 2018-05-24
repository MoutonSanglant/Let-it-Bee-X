using UnityEngine;
using System.Collections;

public class Bud : MonoBehaviour
{
	public GameObject Plateformes, Pollen;
	public bool IsOpen
	{
		get
		{
			return _isOpen;
		}
	}
	bool _isOpen;

	public void EnablePlatforms()
	{
		TouchManager.Instance.SetIsUsed(true);
		_isOpen = true;
		Plateformes.SetActive(true);
		Pollen.SetActive (true);
		StartCoroutine(DisableCanTouch());
	}

	IEnumerator DisableCanTouch()
	{
		yield return new WaitForSeconds(0.1f);
		TouchManager.Instance.SetIsUsed(false);
	}
}
