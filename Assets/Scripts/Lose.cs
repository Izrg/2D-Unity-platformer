using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {

	private int buttonWidth = 200;
	private int buttonHeight = 50;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI () {
		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2, ((Screen.height / 2 - buttonHeight / 2) + 100), buttonWidth, buttonHeight), "Return to Menu")) {
			Application.LoadLevel (0);		
		}
	}
}
