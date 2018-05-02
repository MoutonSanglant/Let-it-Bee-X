using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {
	public Slider Slider;
	public float Speed = 2;
	Coroutine _move;
	Rigidbody2D _rigid;
	bool _isMoving;
	float _sliderDistance = 35f;
	float _startPos;
	Vector2 _minSliderPos;
	Vector2 _maxSliderPos;

	void Awake() {
		_isMoving = false;
		Slider.gameObject.SetActive(false);
		_rigid = GetComponent<Rigidbody2D>();
		_minSliderPos = new Vector2(Screen.width / 10, 0);
		_maxSliderPos = new Vector2(Screen.width / 2, Screen.height - (Screen.height / 10));
	}

	public void OnTouchDown() {
		if (_isMoving)
			return;
		_isMoving = true;
		Slider.gameObject.SetActive(true);
/*		if (Input.touchCount != 0)
			_startPos = Input.GetTouch(Input.touchCount - 1).position.x;
		else
			_startPos = Input.mousePosition.x;
	*/
		if (Touch.TouchCount() != 0)
			_startPos = Touch.GetPos().x;
		_move = StartCoroutine(IsMoving());
	}

	IEnumerator IsMoving() {
		var currentTouch = Touch.TouchCount() - 1;
		int touchId = 0;
		if (Touch.TouchCount() != 0)
			touchId = Touch.TouchID(currentTouch);
		while (true)
		{
			for (int i = 0; i < Touch.TouchCount(); i++)
			{
				/*if (Input.GetTouch(i).fingerId == touchId)
				{
					currentTouch = i;
					break;
				}*/
				if (Touch.TouchID(i) == touchId)
				{
					currentTouch = i;
					break;
				}
			}
			Vector2 touchPos;
			if (Touch.TouchCount() != 0)
				touchPos = Touch.GetPos();
			else
				touchPos = Input.mousePosition;
			var tmp = new Vector2(touchPos.x, touchPos.y + _sliderDistance);
			tmp.x = Mathf.Clamp(tmp.x, _minSliderPos.x, _maxSliderPos.x);
			tmp.y = Mathf.Clamp(tmp.y, _minSliderPos.y, _maxSliderPos.y);
			Slider.gameObject.transform.position = tmp;
			Slider.value = touchPos.x - _startPos;
			yield return new WaitForFixedUpdate();
			_rigid.velocity = new Vector2(Slider.value * Speed * Time.deltaTime, _rigid.velocity.y);
		}
	}

	public void OnTouchUp() {
		_isMoving = false;
		Slider.gameObject.SetActive(false);
		StopCoroutine(_move);
	}
}