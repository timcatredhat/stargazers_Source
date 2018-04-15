using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_control : MonoBehaviour {
	public float timealive, currtime;
	public GameObject[] enemies;
	public GameObject player, blood;
	public int damage;
	public bool killit, shootright, shootleft;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		killit = false;
		damage = 1;
		enemies = GameObject.FindGameObjectsWithTag ("enemy");
		timealive = 1;
		currtime = Time.time;
		Destroy (gameObject, 0.4f); //if it hits nothing make bullet go away

		if ((player.GetComponent<player_controller> ().eyeright && !shootleft) || (player.GetComponent<player_controller> ().lastdir == 1 && !shootleft)) {
			shootright = true; //is the player facing right?
		}
		if ((player.GetComponent<player_controller> ().eyeleft && !shootright) || (player.GetComponent<player_controller> ().lastdir == 0 && !shootright)) {
			shootleft = true; //is the player facing left?
		}
	}
	
	void Update () {
		if (shootleft) {
			transform.Translate (new Vector3 (-5, 0) * 4 * Time.deltaTime); //was the bullet shot left?
		}
		if (shootright) {
			transform.Translate (new Vector3 (5, 0) * 4 * Time.deltaTime); //was the bullet shot right?
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "enemy") { //if bullet hit enemy
			killit = true;
			col.GetComponent<enemyhealth> ().takedamage (damage); //do damage to enemy
			Instantiate (blood, gameObject.transform.position, Quaternion.identity); //make blood pop up
			Destroy (gameObject); //make bullet go away
		} else {
			killit = false;
		}
	}
}
