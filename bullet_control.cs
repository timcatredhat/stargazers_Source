using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_control : MonoBehaviour {
	public float timealive, currtime;
	public GameObject[] enemies;
	public GameObject player, blood;
	public int damage;
	public bool killit, shootright, shootleft;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		killit = false;
		damage = 1;
		enemies = GameObject.FindGameObjectsWithTag ("enemy");
		timealive = 1;
		currtime = Time.time;
		Destroy (gameObject, 0.4f);

		if ((player.GetComponent<player_controller> ().eyeright && !shootleft) || (player.GetComponent<player_controller> ().lastdir == 1 && !shootleft)) {
			shootright = true;
		}
		if ((player.GetComponent<player_controller> ().eyeleft && !shootright) || (player.GetComponent<player_controller> ().lastdir == 0 && !shootright)) {
			shootleft = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (shootleft) {
			transform.Translate (new Vector3 (-5, 0) * 4 * Time.deltaTime);
		}
		if (shootright) {
			transform.Translate (new Vector3 (5, 0) * 4 * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "enemy") {
			killit = true;
			col.GetComponent<enemyhealth> ().takedamage (damage);
			Instantiate (blood, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		} else {
			killit = false;
		}
	}
}
