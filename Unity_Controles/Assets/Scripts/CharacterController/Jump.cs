using System.Collections;
using UnityEngine;

public class Jump : MonoBehaviour {
	public Transform GroundCheck;
	public LayerMask Ground;
	public float JumpForce = 2f;
	Rigidbody2D _rigid;
	Coroutine _jump;
	bool _isJumping;
	float _startPos;

	void Awake () 
    {
		_isJumping = false;
		_rigid = GetComponent<Rigidbody2D>();
	}

	bool IsGrounded()
	{
		return (Physics2D.OverlapCircle(GroundCheck.position, 0.1f, Ground));
	}

	public void OnTouchDown() {
		if (_isJumping)
			return;
		_isJumping = true;
		var touchCount = Input.touchCount - 1;
		if (Input.touchCount != 0)
			_startPos = Input.GetTouch(touchCount).position.y;
		else
			_startPos = Input.mousePosition.y;
		_jump = StartCoroutine(IsJumping());
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
			var distance = touchPos.y - _startPos;
			if ((distance > 10 && IsGrounded()) || distance < -10)
			{
				distance = Mathf.Clamp(distance, -10, 10);
				yield return new WaitForFixedUpdate();
				_rigid.AddRelativeForce(new Vector2(0, distance * JumpForce), ForceMode2D.Impulse);
				_startPos = touchPos.y;
			}
			yield return null;
		}
	}

	public void OnTouchUp() {
		_isJumping = false;
		StopCoroutine(_jump);
	}
}
