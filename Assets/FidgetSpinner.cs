using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FidgetSpinner : MonoBehaviour {

	private Touch touch;
	private Vector2 touch_position;
	private int direction;
	private float startx;
	private float curx;
	private float endx;
	private bool direction_chosen;
	private static Gyroscope gyro;

	public bool isSpinning = false;

	// Use this for initialization
	void Start () {
		gyro = Input.gyro;
		if(!gyro.enabled)
		{
			gyro.enabled = true;
		}
	}

	// Update is called once per frame
	void Update () {

		if (isSpinning) {
			//transform.Rotate (Vector3.up, (Time.deltaTime * 500) * direction);
			gameObject.transform.rotation = gyro.attitude;
		}

		if (Input.touchCount > 0) {
			touch = Input.GetTouch (0);

			//transform.Rotate(Vector3.up, ((touch.position.x - 700)/100)*-1);

			if (!isSpinning) {

				switch (touch.phase) {
				case TouchPhase.Began:
					startx = touch.position.x - 700;
					break;

				case TouchPhase.Ended:
					endx = touch.position.x - 700;
					break;
				}

				if (startx > 0 && endx < 0) {
					isSpinning = true;
					direction = 1;
					//starttimer();
					//startgyro();
					//transform.Rotate (Vector3.up, Time.deltaTime * 100);
				} 
				else if(startx < 0 && endx > 0) {
					isSpinning = true;
					direction = -1;
				}
			}
		}

	}
}
