using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_follow : MonoBehaviour {
	public GameObject player;
	public bool chaseison = false;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		if (GetComponent<enemy_attack> ().tofollow) {
			if (Vector3.Distance (player.transform.position, gameObject.transform.position) >= 6) {
				chaseison = true;
			}
		}

		if (chaseison) {
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-8.3f, 0);
		}
	}
}
