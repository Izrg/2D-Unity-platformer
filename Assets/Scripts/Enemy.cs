using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	public float speed = 3f;
	public bool stomp = false;
	public bool flying;
	void Start(){

	}
	public bool collide;
	// Update is called once per frame
	void Update () {
		if (!flying) {
			rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
		} else {
			rigidbody2D.velocity = new Vector2(speed, 0);	
		}
		//collide = Physics2D.Linecast (sightStart.position, sightEnd.position);
		if (stomp){
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name == "Wall") {
			transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
			speed *= -1;
		//Damage the player, then turn around
		}else if(coll.gameObject.name == "Player"){
			GameObject go = GameObject.Find("Player");
			Player obPlayer = go.GetComponent<Player>();
			obPlayer.damagePlayer(1);
			transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
			speed *= -1;
		}
	}


}
