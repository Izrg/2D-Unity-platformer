using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	public int jumpDelay = 2;
	public float step = 0.05f;
	private float xPos;
	private float yPos;
	private float topJump = 4;
	private bool up = true;
	private bool down = false;
	private float botJump;
	private int range = 1;
	public int bossHealth;
	//Player obPlayer = gO.GetComponent<Player>();
	// Use this for initialization
	void Start () {
		xPos = transform.position.x;
		yPos = transform.position.y;
		botJump = yPos;
		bossHealth = 3;
		//transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
	}
	
	// Update is called once per frame
	void Update () {
		//this.StartCoroutine (this.jump ());
		float tempY = transform.position.y;
		if (bossHealth > 0) {
			//float tempY = transform.position.y;
			GameObject gO = GameObject.Find("Player");
			Player obPlayer = gO.GetComponent<Player>();
			

			if (tempY >= topJump) {
				up = false;
			}
			//Move up the screen .
			if (up) {
				transform.position = new Vector2(transform.position.x, tempY += step);
			} else {
				
				float playerX = obPlayer.gameObject.transform.position.x;
				//If the enemy is above the player, move down.
				if(down){
					transform.position = new Vector2(transform.position.x, tempY -= step);
					if(tempY <= botJump){
						up = true;
						down= false;
					}
					return;
				}
				
				
				if(!down){
					//Checks if the boss is within range.
					if( Mathf.Abs((transform.position.x - playerX)) < range){
						down = true;
						transform.position = new Vector2(transform.position.x, tempY -= step);
						return;
					}
					
					float tempX = transform.position.x;
					if(tempX >= playerX){
						transform.position = new Vector2(tempX -= step, transform.position.y);
					}else{
						transform.position = new Vector2(tempX += step, transform.position.y);
					}
					
				}
				//Debug.Log("ENEMY X: " + transform.position.x + "PLAYER X: " + playerX);
				//Debug.Log(down);
				//transform.position = new Vector2(transform.position.x, tempY -= step);
			}

		}
		if(bossHealth <= 0){
			Destroy (GameObject.Find("Bomb"));
			transform.position = new Vector2(transform.position.x, tempY += step);
			SpriteRenderer sr = GameObject.Find("Button").GetComponent<SpriteRenderer>();
			sr.enabled = true;
			//GameObject.Find("Button").SetActive(true);
		}
	}

	public IEnumerator jump(){
		yield return new WaitForSeconds (jumpDelay);


	}

	void OnCollisionEnter2D(Collision2D coll){
		//If colliding with the bomb...
		if (coll.gameObject.name == "Bomb") {
			Debug.Log("MIN: " + ((GameObject.Find ("Wall1").transform.position.x) + 16));
			Debug.Log("MAX: " + ((GameObject.Find ("Wall2").transform.position.x) - 6));

			//float tempNum = Random.Range ((GameObject.Find ("Wall1").transform.position.x) + 16, (GameObject.Find ("Wall2").transform.position.x)) - 6;
			float tempNum = Random.Range(8.5f,43);
			coll.gameObject.transform.position = new Vector2 (tempNum, coll.gameObject.transform.position.y);
			//Debug.Log("BOOM!");
			up = true;
			down = false;
			step += 0.09f;
			bossHealth -= 1;

		//If coliding with the player...
		} else if (coll.gameObject.name == "Player") {
			up = true;
			down = false;
			GameObject gO = GameObject.Find("Player");
			Player obPlayer = gO.GetComponent<Player>();
			obPlayer.damagePlayer(1);
		}
	}
}
