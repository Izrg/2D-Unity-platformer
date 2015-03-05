using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int fallBoundry = -20;
	[System.Serializable]
	public class PlayerStats{
		public  int health = 3;
		public static  int maxHealth = 3;
		public static int lives = 3;
	}
	public bool invincible = false;
	Texture2D heart;
	Texture2D emptyHeart;
	public PlayerStats ps = new PlayerStats();



	void Start(){
		ps.health = PlayerStats.maxHealth;
		heart = (Texture2D)Resources.Load ("hud_heartFull");
		emptyHeart = (Texture2D)Resources.Load ("hud_heartEmpty");
		//Debug.Log (ps.health);
		//DontDestroyOnLoad (transform.gameObject);
	}

	void Update(){
		if (transform.position.y <= fallBoundry) {
			damagePlayer(999);
		}
	}

	void OnGUI(){
		int guiStep = 0;
		GUI.Label (new Rect (10, 50, 100, 50), "Lives: " + PlayerStats.lives);
		//Draws the hearts on the screen based on the players health
			for (int i = 0; i < ps.health; i++) {
				GUI.DrawTexture (new Rect (10 + guiStep, 10, 30, 30), heart);
				guiStep += 30;
			}
			//Fill the rest of the hearts with empty hearts.
			for (int i = ps.health; i < PlayerStats.maxHealth; i++) {
				GUI.DrawTexture (new Rect (10 + guiStep, 10, 30, 30), emptyHeart);
				guiStep += 30;
			}
	}

	public void damagePlayer (int rDamage){
		ps.health -= rDamage;
		//If the health is less than 0, kill the player
		if (ps.health <= 0) {
			PlayerStats.lives -= 1;
			//Show lose game screen when player runs out of lives.
			if(PlayerStats.lives <= 0){
				//Simply kill the player, and dont respawn him
				GameMaster.endKill(this);
				Application.LoadLevel (4);
			}
			//Kill the player
			GameMaster.killPlayer (this);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		//Increase maximum health by 1;
		if (coll.gameObject.name == "HeartContainer") {
						PlayerStats.maxHealth += 1;
						Destroy (coll.gameObject);
						//Increase current health by 1;
				} else if (coll.gameObject.name == "Health") {
						if (ps.health >= PlayerStats.maxHealth) {
								return;
						}	
						ps.health += 1;
						Destroy (coll.gameObject);
				//If the player touches the game sign.
				} else if (coll.gameObject.name == "signExit") {
				GameMaster.endKill(this);	
				Application.LoadLevel(1);
		}
	}
	public Player getPlayer(){
		return this;
	}

}
