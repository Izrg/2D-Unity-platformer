using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private string instructions = "Instructions:\n Press A and D or Left and Right arrow keys to move\n Press space to jump\n Get to the end of the action packed levels!!";
	private int buttonWidth = 200;
	private int buttonHeight = 50;


	// Update is called once per frame
	void OnGUI () {
		GUI.Label (new Rect (10, 10, 400, 200), instructions);
		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2, Screen.height / 2 - buttonHeight / 2, buttonWidth, buttonHeight), "Start Game!!")) {
			//set the intial lives of the player
			Player.PlayerStats.lives = 3;
			Player.PlayerStats.maxHealth = 3;
			GameMaster.currentLevel = 2;
			Application.LoadLevel (GameMaster.currentLevel);		
		}
	}
}
