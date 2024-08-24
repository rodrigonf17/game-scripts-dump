using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawn player/character game object
public class SpawnPlayer : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("spawned", 0);
		if (PlayerPrefs.GetInt ("spawned") == 0) {
			GameObject newPlayer = Instantiate (player, transform.position, Quaternion.identity);
			newPlayer.name = "Player";
			PlayerPrefs.SetInt("spawned", 1);
		}
	}
	
}
