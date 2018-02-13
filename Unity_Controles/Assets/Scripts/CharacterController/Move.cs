using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {
	public Slider slider;
	Coroutine move;
	Rigidbody2D rigid;
	bool isMoving;
	public float sliderDistance = 10;
	float startPos;
	public Vector2 minSliderPos;
	public Vector2 maxSliderPos;
	public float speed = 2;

	void Awake() {
		isMoving = false;
		slider.gameObject.SetActive(false);
		rigid = GetComponent<Rigidbody2D>();
		minSliderPos.x = Screen.width / 10;
		maxSliderPos.x = Screen.width / 2;
		maxSliderPos.y = Screen.height - (Screen.height / 10);
	}

	public void OnTouchDown() {
		if (isMoving)
			return;
		isMoving = true;
		slider.gameObject.SetActive(true);
		if (Input.touchCount != 0)
			startPos = Input.GetTouch(Input.touchCount - 1).position.x;
		else
			startPos = Input.mousePosition.x;
		move = StartCoroutine(IsMoving());
	}

	IEnumerator IsMoving() {
		var currentTouch = Input.touchCount - 1;
		int touchId = 0;
		if (Input.touchCount != 0)
			touchId = Input.GetTouch(currentTouch).fingerId;
		while (true)
		{
			for (int i = 0; i < Input.touchCount; i++)
			{
				if (Input.GetTouch(i).fingerId == touchId)
				{
					currentTouch = i;
					break;
				}
			}
			Vector2 touchPos;
			if (Input.touchCount != 0)
				touchPos = Input.GetTouch(currentTouch).position;
			else
				touchPos = Input.mousePosition;
			var tmp = new Vector2(touchPos.x, touchPos.y + sliderDistance);
			tmp.x = Mathf.Clamp(tmp.x, minSliderPos.x, maxSliderPos.x);
			tmp.y = Mathf.Clamp(tmp.y, minSliderPos.y, maxSliderPos.y);
			slider.gameObject.transform.position = tmp;
			slider.value = touchPos.x - startPos;
			yield return new WaitForFixedUpdate();
			rigid.velocity = new Vector2(slider.value * speed * Time.deltaTime, rigid.velocity.y);
		}
	}

	public void OnTouchUp() {
		isMoving = false;
		slider.gameObject.SetActive(false);
		StopCoroutine(move);
	}
}