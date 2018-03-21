using UnityEngine;

public class Bud : MonoBehaviour
{
	public GameObject Plateformes;
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
		_isOpen = true;
		Plateformes.SetActive(true);
	}
}
