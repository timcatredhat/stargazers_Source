using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_control : MonoBehaviour {
	public bool killit, killit2;
	public GameObject player, blood, son;
	public float damage = 1f;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		son = GameObject.FindGameObjectWithTag ("friend1");
		Destroy (gameObject, 0.4f); //bullet disappears if it hits nothing

	}
	
	void Update () {
		transform.Translate (new Vector3 (-5, 0) * 4 * Time.deltaTime); //enemy bullets fly left

		if (player != null) {
			if (killit) {
				player.GetComponent<player_controller> ().takedamage (damage); //if they hit a player, make the player take damage
				Instantiate (blood, gameObject.transform.position, Quaternion.identity); //show blood
				Destroy (gameObject); //make bullet go away after
			}
		}
		if (killit2) {
			son.GetComponent<son_control> ().takedamage (damage); //if the bullet hits the son, make the son take damage
			Instantiate (blood, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject); //make bullet go away after
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") { //check if hits player
			killit = true;
		} else if (col.gameObject.tag == "friend1") { //check if hits son
			killit2 = true;
		}else {
			killit = false;
		}
	}
}