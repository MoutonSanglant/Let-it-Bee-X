using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour {
	Coroutine jump;
	Rigidbody2D rigid;
	public Transform groundCheck;
	bool isJumping;
	float startPos;
	public LayerMask ground;
	public float jumpForce = 2f;

	void Awake () 
    {
		isJumping = false;
		rigid = GetComponent<Rigidbody2D>();
	}

	bool IsGrounded()
	{
		return (Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground));
	}

	public void OnTouchDown() {
		if (isJumping)
			return;
		isJumping = true;
		var touchCount = Input.touchCount - 1;
		if (Input.touchCount != 0)
			startPos = Input.GetTouch(touchCount).position.y;
		else
			startPos = Input.mousePosition.y;
		jump = StartCoroutine(IsJumping());
	}

	IEnumerator IsJumping() {
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
			var distance = touchPos.y - startPos;
			if ((distance > 10 && IsGrounded()) || distance < -10)
			{
				distance = Mathf.Clamp(distance, -10, 10);
				yield return new WaitForFixedUpdate();
				rigid.AddRelativeForce(new Vector2(0, distance * jumpForce), ForceMode2D.Impulse);
				startPos = touchPos.y;
			}
			yield return null;
		}
	}

	public void OnTouchUp() {
		isJumping = false;
		StopCoroutine(jump);
	}
}
