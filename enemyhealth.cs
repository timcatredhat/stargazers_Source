using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour {
	private int health;
	public GameObject ouch;
	// Use this for initialization
	void Start () {
		health = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			//Destroy (gameObject);
			if (name == "enemy0") {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<player_controller> ().killedron = true;
			}
			if (name == "enemy1") {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<player_controller> ().killedjan = true;
			}
			if (name == "enemy2") {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<player_controller> ().killedmoe = true;
			}
			if (name == "enemy01") {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<player_controller> ().killedrae = true;
			}
			if (name == "enemy02") {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<player_controller> ().killedskye = true;
			}
			GameObject.FindGameObjectWithTag("Player").GetComponent<player_controller>().killct ++;
			print (GameObject.FindGameObjectWithTag("Player").GetComponent<player_controller>().killct);
			gameObject.SetActive(false);
		}

		if (gameObject.transform.position.y <= -300) {
			Destroy (gameObject);
		}
	}

	public void takedamage(int dmg) {
		if (gameObject.name == "enemy03" || gameObject.name == "truck") {

		} else {
			health -= dmg;
			GameObject bullet = Instantiate (ouch);
			bullet.transform.position = this.transform.position + new Vector3 (0, 0.5f, 0);
			bullet.transform.rotation = this.transform.rotation;
		}
	}

	public int gethealth() {
		return health;
	}

	public void sethealth(int h) {
		health = h;
	}
}
