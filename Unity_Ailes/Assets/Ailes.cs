using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ailes : MonoBehaviour {

	public GameObject WindEffectiveArea, PollenContainer;
	public float ThrowRate, ThrowStartDelay;

	private bool _touchOnPlayer;
	private Rigidbody2D _playerRig;
	private CircleCollider2D _col;
	private Touch _firstTouch;
	private Vector3 _firstTouchPos;
	private Vector2 _touchHeading;
	private Wind _wind;
	private float _touchDist, _activationDist;

	void Awake() 
	{
		_playerRig = GetComponentInParent<Rigidbody2D> ();
		_col = GetComponent<CircleCollider2D> ();
		_wind = WindEffectiveArea.GetComponent<Wind> ();
		_activationDist = _wind.MinDist;

	}

	void Update() 
	{
		if (Input.touchCount != 0) 
		{
			RegisterTouchInfos ();
			if (_firstTouch.phase == TouchPhase.Began && _col.OverlapPoint(_firstTouchPos)) 
			{
				TouchOnPlayer ();
			}
			if (_touchOnPlayer && _touchDist >= _activationDist) 
			{
				EnableTouchArea ();
				InvokeRepeating ("ThrowGrain", ThrowStartDelay, ThrowRate);
			}
			if (WindEffectiveArea.activeSelf) 
			{
				RotateToTouch ();
			}
			_wind.TouchDist = _touchDist;
			if (_firstTouch.phase == TouchPhase.Ended) 
			{
				CancelInvoke ("ThrowGrain");
				DisableTouchArea ();
			}
		}
	}

	private void RegisterTouchInfos() 
	{
		_firstTouch = Input.GetTouch (0);
		_firstTouchPos = Camera.main.ScreenToWorldPoint (_firstTouch.position);
		_touchHeading = _firstTouchPos - transform.position;
		_touchDist = _touchHeading.magnitude;
	}

	private void TouchOnPlayer() 
	{
		_playerRig.bodyType = RigidbodyType2D.Static;
		_touchOnPlayer = true;
	}

	private void EnableTouchArea() 
	{
		_touchOnPlayer = false;
		WindEffectiveArea.SetActive (true);
	}

	private void RotateToTouch() 
	{
		_wind.PushDirection = _touchHeading;
		float _rotateDirection = Mathf.Atan2 (_touchHeading.y, _touchHeading.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, _rotateDirection - 180);
	}

	private void DisableTouchArea() 
	{
		_playerRig.bodyType = RigidbodyType2D.Dynamic;
		WindEffectiveArea.SetActive (false);
	}

	private void ThrowGrain() 
	{
		foreach (Transform child in PollenContainer.transform) 
		{
			if (child.childCount != 0) 
			{
				Transform _grain = child.GetChild (0);
				if (_grain.tag != "Movable") 
				{
					PlayerPollen.GrainCount--;
					_grain.gameObject.layer = 0;
					_grain.gameObject.GetComponent<PollenGrain> ().AttachedToPlayer = false;
					_grain.tag = "Movable";
					break;
				}
			}
		}
	}
}
