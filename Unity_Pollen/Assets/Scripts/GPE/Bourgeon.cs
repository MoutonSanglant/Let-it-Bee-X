using UnityEngine;

public class Bourgeon : MonoBehaviour {
	
	public LayerMask PlayerLayer;
	public GameObject Plateformes;
	public float CastRadius = 1f;
	public GameObject Pollen;
	public GameObject PollenDetector;

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
		PollenDetector.SetActive (false);
		Pollen.SetActive (true);
	}

	public void PullTrigger(Collider2D collider) 
	{
		if (collider.gameObject.name == "Player") 
		{
			AttachedPollen _player = collider.GetComponent<AttachedPollen> ();
			if (_player.HasPollen && _player.PollenColor == gameObject.transform.parent.tag) 
			{
				EnablePlatforms ();
				_player.DetachPollen ();
			}
		}
	}
}
