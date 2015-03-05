using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour {
	private float xPos;
	private float yPos;
	private bool max = false;

	public bool vert;
	public int maxAmount;
	public float step;
	// Use this for initialization
	void Start () {
		xPos = transform.position.x;
		yPos = transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {
		//Check vertical max
		if (vert) {
			if (transform.position.y >= (yPos + maxAmount)) {
				max = true;
			} else if (transform.position.y <= yPos) {
				max = false;
			}
		//Check horizontal Max
		} else {
			if (transform.position.x >= (xPos + maxAmount)) {
				max = true;
			} else if (transform.position.x <= xPos) {
				max = false;
			}		
		}

		//Moving the Platform.
		//If moving up/down
		if (vert) {
			float tempY = transform.position.y;
			if (!max) {
				transform.position = new Vector2(transform.position.x, tempY += step);
			} else {
				transform.position = new Vector2(transform.position.x, tempY -= step);
			}
		//Horizontal movement left/right
		} else {
			float tempX = transform.position.x;
			if (!max) {
				transform.position = new Vector2(tempX += step, transform.position.y);
			} else {
				transform.position = new Vector2(tempX -= step, transform.position.y);
			}		
		}

	}
}
