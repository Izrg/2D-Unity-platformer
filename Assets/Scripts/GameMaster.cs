using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;
	public static Player p;
	public static int currentLevel;
	void Start(){
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		//p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		DontDestroyOnLoad (transform.gameObject);
	}
	void Update(){

	}

	public Transform playerPrefab;
	public Transform spawnPoint;
	public int spawnDelay = 2;

	public IEnumerator respawn (){
		yield return new WaitForSeconds (spawnDelay);
		Object clone = Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
		//Make sure that the name of the new clone is always the name of the object it cloned.
		//In this case, "Player"
		int pos = clone.name.IndexOf ("(");
		clone.name = clone.name.Substring (0, pos);
	}

	void OnLevelWasLoaded(int level){
		if (level == 1) {
			Player.PlayerStats.maxHealth = 3;
			Player.PlayerStats.lives = 3;
		}
		if (level == 2) {
			//Set the new spawn point on this level
			spawnPoint = GameObject.FindGameObjectWithTag("SP").transform;
		}
		if (level == 3) {
			//Set the new spawn point on this level.
			spawnPoint = GameObject.FindGameObjectWithTag("SP2").transform;
			SpriteRenderer sr = GameObject.Find("Button").GetComponent<SpriteRenderer>();
			sr.enabled = false;
			//GameObject.Find("Button").SetActive(false);
		}
		if (level == 4) {
			Debug.Log("test 4");
			//Destoyes the gamemaster on game end.
			Destroy(this.gameObject);
		}
	}

	//Called at the beginning of a new level to respawn the player
	public static void endRespawn(){
		gm.StartCoroutine (gm.respawn ());
	}
	//Called at the end of the level to kill the player
	public static void endKill(Player player){
		Destroy (player.gameObject);
	}

	public static void killPlayer(Player player){
		gm.StartCoroutine(gm.respawn ());
		Destroy (player.gameObject);

	}
	public static void setSpawnPoint(Transform t){
		gm.spawnPoint = t;
	}

}
