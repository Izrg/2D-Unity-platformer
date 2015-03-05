using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {


	private int buttonWidth = 200;
	private int buttonHeight = 50;
	// Use this for initialization
	void OnGUI () {
		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2, Screen.height / 2 - buttonHeight / 2, buttonWidth, buttonHeight), "Next Level")) {
			//set the intial lives of the player
			Player.PlayerStats.lives = 3;
			//GameMaster.endRespawn();
			GameMaster.currentLevel += 1;
			Application.LoadLevel(3);
		}
	}
}
