using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attack : MonoBehaviour {
	public GameObject player, enemybullet;
	public bool shooting, meh, ready, tofollow = false;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		InvokeRepeating ("shoot", 0, 0.15f);
		if (gameObject.name == "enemy0" || gameObject.name == "enemy1") {
			ready = false;
		} else {
			ready = true;
		}
	}

	// Update is called once per frame
	void Update () {


		if (gameObject.name != "truck") {
			if (Vector3.Distance (transform.position, player.transform.position) <= 1.2f && player != null) {
				player.GetComponent<player_controller> ().enemytouched = true;
			}

			if (Vector3.Distance (transform.position, player.transform.position) <= 6 && player != null && Mathf.Abs (transform.position.y - player.transform.position.y) <= 2f) {
				StartCoroutine ("getready");
				if (ready) {
					if (shooting) {
						if (meh) {
							GameObject bulletclone = Instantiate (enemybullet, transform.position, transform.rotation);
							meh = false;				
						}
					}
				}
			}
		} else {
			if (Vector3.Distance (transform.position, player.transform.position) <= 1.2f && player != null) {
				player.GetComponent<player_controller> ().enemytouched = true;
			}

			if (player.GetComponent<player_controller>().truckmove && Vector3.Distance (transform.position, player.transform.position) <= 6 && player != null && Mathf.Abs (transform.position.y - player.transform.position.y) <= 2f) {
				StartCoroutine ("getready");
				if (ready) {
					if (shooting) {
						if (meh) {
							GameObject bulletclone = Instantiate (enemybullet, transform.position, transform.rotation);
							meh = false;				
						}
					}
				}
			}
		}
	}

	void shoot() {
		shooting = !shooting;
		if (shooting) {
			meh = true;
		}
	}

	IEnumerator getready () {
		yield return new WaitForSeconds (3.1f);
		ready = true;
		tofollow = true;
	}
		
}
