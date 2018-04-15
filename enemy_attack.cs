using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attack : MonoBehaviour {
	public GameObject player, enemybullet;
	public bool shooting, shot, ready, tofollow = false;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		InvokeRepeating ("shoot", 0, 0.15f); //controls rate of fire
		if (gameObject.name == "enemy0" || gameObject.name == "enemy1") { //certain enemies don't attack, like the one who begs
			ready = false;
		} else {
			ready = true;
		}
	}

	void Update () {

		if (gameObject.name != "truck") { //is the enemy type an end game truck?
			if (Vector3.Distance (transform.position, player.transform.position) <= 1.2f && player != null) {
				player.GetComponent<player_controller> ().enemytouched = true;
			}

			if (Vector3.Distance (transform.position, player.transform.position) <= 6 && 
				player != null && Mathf.Abs (transform.position.y - player.transform.position.y) <= 2f) {
				StartCoroutine ("getready");
				if (ready) {
					if (shooting) {
						if (shot) {
							GameObject bulletclone = Instantiate (enemybullet, transform.position, transform.rotation); //fire a bullet
							shot = false;				
						}
					}
				}
			}
		} else {
			if (Vector3.Distance (transform.position, player.transform.position) <= 1.2f && player != null) { //is the enemy not a truck?
				player.GetComponent<player_controller> ().enemytouched = true;
			}

			if (player.GetComponent<player_controller>().truckmove && 
				Vector3.Distance (transform.position, player.transform.position) <= 6 && 
				player != null && Mathf.Abs (transform.position.y - player.transform.position.y) <= 2f) {
				StartCoroutine ("getready");
				if (ready) {
					if (shooting) {
						if (shot) {
							GameObject bulletclone = Instantiate (enemybullet, transform.position, transform.rotation); //fire a bullet
							shot = false;				
						}
					}
				}
			}
		}
	}

	void shoot() { //controls rate of bullet fire
		shooting = !shooting;
		if (shooting) {
			shot = true;
		}
	}

	IEnumerator getready () { //delay between dialogue and fire
		yield return new WaitForSeconds (3.1f);
		ready = true;
		tofollow = true;
	}		
}