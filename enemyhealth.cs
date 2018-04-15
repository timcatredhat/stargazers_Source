using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour {
	private int health;
	public GameObject ouch;

	void Start () {
		health = 10; //each enemy starts with 10 health
	}
	
	void Update () {
		if (health <= 0) { //below controls the popups of enemy profiles if they are killed by the player
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
			GameObject.FindGameObjectWithTag("Player").GetComponent<player_controller>().killct ++; //if player kills enemy, boost their kill count
			print (GameObject.FindGameObjectWithTag("Player").GetComponent<player_controller>().killct);
			gameObject.SetActive(false); //if enemy dead make it disappear
		}

		if (gameObject.transform.position.y <= -300) {
			Destroy (gameObject); //if enemy falls off a ledge into the precipice, make them die
		}
	}

	public void takedamage(int dmg) {
		if (gameObject.name == "enemy03" || gameObject.name == "truck") { //the trucks or end scene enemies can't be harmed to force ending

		} else {
			health -= dmg;
			GameObject bullet = Instantiate (ouch); //if bullet hit enemy, decrease its health
			bullet.transform.position = this.transform.position + new Vector3 (0, 0.5f, 0);
			bullet.transform.rotation = this.transform.rotation;
		}
	}

	public int gethealth() { //get enemy health
		return health;
	}

	public void sethealth(int h) { //set enemy health
		health = h;
	}
}