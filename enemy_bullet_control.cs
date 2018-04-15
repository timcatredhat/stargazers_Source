using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_control : MonoBehaviour {
	public bool killit, killit2;
	public GameObject player, blood, son;
	public float damage = 1f;
	//public bool shootleft;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		son = GameObject.FindGameObjectWithTag ("friend1");
		Destroy (gameObject, 0.4f);

	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (new Vector3 (-5, 0) * 4 * Time.deltaTime);

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
