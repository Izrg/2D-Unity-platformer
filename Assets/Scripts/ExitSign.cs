using UnityEngine;
using System.Collections;

public class ExitSign : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name == "Player") {
			//GameMaster.setSpawnPoint(GameObject.Find("SpawnPoint2").transform);

		}
	}
}
