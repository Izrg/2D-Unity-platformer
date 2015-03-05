using UnityEngine;
using System.Collections;

public class Stomp : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll){
		//If the player jumps on the enemy, they get crushed.
		if (coll.gameObject.name == "Player") {
			Debug.Log("CRUSHED!");
			transform.root.gameObject.GetComponent<Enemy>().stomp = true;
		}
	}
}
