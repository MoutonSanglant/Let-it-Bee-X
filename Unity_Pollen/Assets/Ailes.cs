using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ailes : MonoBehaviour {

	public Pollen Player;
	public GameObject BudDetectedSprite;
	public LayerMask RayCastMask;
	public float WingsMaxRange, WingsMinRange;

	private bool _wingsActive;
	private CircleCollider2D _col;

	void Awake() {
		_wingsActive = false;
		_col = GetComponent<CircleCollider2D> ();
	}

	void Update() {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			Vector3 touchPos = Camera.main.ScreenToWorldPoint (touch.position);
			if (Player.hasPollen && touch.phase == TouchPhase.Began && _col.OverlapPoint(touchPos)) {
				_wingsActive = true;
			}
			if (_wingsActive) {
				EnbaleWings (touch);
			}
			if (touch.phase == TouchPhase.Ended) {
				DisableWings ();
			}
		}
	}

	void EnbaleWings(Touch touch) {
		Vector2 rayCastDirection = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, rayCastDirection, WingsMaxRange, RayCastMask);
		Debug.DrawRay (transform.position, rayCastDirection * 4, Color.blue);
		if (hit && hit.collider.tag == "Closed Bud" && hit.distance > WingsMinRange) {
			BudDetectedSprite.SetActive (true);
			PollenTrigger targetBud = hit.collider.gameObject.GetComponentInParent<PollenTrigger> ();
			if (targetBud.FlowerPollen.PollenColor == Player.PollenColor) {
				targetBud.EnablePlatforms ();
			}
		} else {
			BudDetectedSprite.SetActive (false);
		}
	}

	void DisableWings() {
		_wingsActive = false;
		BudDetectedSprite.SetActive (false);
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, WingsMaxRange);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, WingsMinRange);
	}

}
