using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll){
		///If the layer jumps on spikes, he will die.
		if (coll.gameObject.name == "Player") {
			GameObject go = GameObject.Find("Player");
			Player obPlayer = go.GetComponent<Player>();
			obPlayer.damagePlayer(999);
		}
	}
}
