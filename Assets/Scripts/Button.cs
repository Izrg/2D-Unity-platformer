using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	private bool moveWall = false;
	private float top = -9.65f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (moveWall) {
			float wallY = GameObject.Find ("Wall2").transform.position.y;
			float walkY = GameObject.Find ("Walkway").transform.position.y;
			GameObject.Find ("Wall2").transform.position = new Vector2(GameObject.Find ("Wall2").transform.position.x, wallY += 0.05f);		
			if(walkY <= top){
				GameObject.Find ("Walkway").transform.position = new Vector2(GameObject.Find ("Walkway").transform.position.x, walkY += 0.05f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		//If colliding with the bomb...
		if (coll.gameObject.name == "Player") {
			GameObject gO = GameObject.Find("Boss");
			Boss obBoss = gO.GetComponent<Boss>();
			if (obBoss.bossHealth <= 0) {
				moveWall = true;
			}	
		}

	}
}
