using UnityEngine;

public class Bourgeon : MonoBehaviour {
	public LayerMask PlayerLayer;
	public GameObject Plateformes;
	public float CastRadius = 1f;

	bool IsPlayerAround () 
	{
		if (Physics2D.OverlapCircle(transform.position, CastRadius, PlayerLayer))
			return (true);
		return (false);
	}

	private void OnMouseUpAsButton()
	{
		if (IsPlayerAround() && !Plateformes.activeSelf)
			EnablePlatforms();
	}

	void EnablePlatforms()
	{
		Plateformes.SetActive(true);
	}
}
