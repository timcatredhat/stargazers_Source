using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_follow : MonoBehaviour {
	public GameObject player;
	public bool chaseison = false;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		if (GetComponent<enemy_attack> ().tofollow) {
			if (Vector3.Distance (player.transform.position, gameObject.transform.position) >= 6) { //chase player to the left
				chaseison = true;
			}
		}

		if (chaseison) {
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-8.3f, 0); //give the enemy gravity
		}
	}
}
