using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_control_right : MonoBehaviour {
	public bool killit, killit2;
	public GameObject player, blood, son;
	public float damage = 1f;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		son = GameObject.FindGameObjectWithTag ("friend1");
		Destroy (gameObject, 0.4f);
	}

	void Update () {

		transform.Translate (new Vector3 (5, -0.2f) * 4 * Time.deltaTime); //same as in enemy_bullet_control class, but for right shooters

		if (player != null) {
			if (killit) {
				player.GetComponent<player_controller> ().takedamage (damage);
				Instantiate (blood, gameObject.transform.position, Quaternion.identity);
				Destroy (gameObject);
			}
		}
		if (killit2) {
			son.GetComponent<son_control> ().takedamage (damage);
			Instantiate (blood, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			killit = true;
		} else if (col.gameObject.tag == "friend1") {
			killit2 = true;
		}else {
			killit = false;
		}
	}
}