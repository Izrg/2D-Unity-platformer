using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
				//If colliding with the bomb...
		if (coll.gameObject.name == "Player") {
			Application.LoadLevel(0);
		}
	}
}
