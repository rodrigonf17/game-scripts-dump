using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	Transform player;
	public Vector3 playerPosition;
	public Vector3 followPos;
	float smoothTime = 0.05f;
	public float offset;
	Vector3 vel = Vector3.zero;

	public Transform L_limit;
	public Transform R_limit;

	void Start () {
		player = GameObject.Find ("Player").transform; 
		L_limit = GameObject.Find ("L_limit").transform; 
		R_limit = GameObject.Find ("R_limit").transform;
		//find the player game object and its limits on the view

		if (player.GetComponent<PlayerMovement> ().spawnOnLeft) {
			transform.position = new Vector3 (-7.95f, 0f, -10f);
		} else if (!player.GetComponent<PlayerMovement> ().spawnOnLeft) {
			transform.position = new Vector3 (7.95f, 0f, -10f);
		}
	}

	void Update () {
		playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
		//update the camera position with player position

		
		// smoothly move the camera towards that target position
		if ((playerPosition.x > (L_limit.position.x+9.55f)) && (playerPosition.x < (R_limit.position.x-9.55f))){
			transform.position = Vector3.SmoothDamp (transform.position, playerPosition, ref vel, smoothTime);
		}
	}

}
