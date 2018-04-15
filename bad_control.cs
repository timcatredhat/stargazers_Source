using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bad_control : MonoBehaviour {
	public Rigidbody bad;
	public Rigidbody pl;
	public GameObject player;
	public int seenct; // checks number of times seen
	public bool isseen; // checks if npc saw the player, if so then...
	public bool hitborder; // checks in npc has reached background border
	public bool collided; // checks if collided with player
	public GameObject winshow; //text showing

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		bad = GetComponent<Rigidbody> ();
		pl = player.GetComponent<Rigidbody> ();
		isseen = false;
		seenct = 0;
		//winshow = GameObject.FindGameObjectWithTag ("textbad");
		//winshow.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (seenct <= 10 && Vector2.Distance (player.transform.position, transform.position) <= 2f && Vector2.Distance (player.transform.position, transform.position) > 1f) {
			isseen = true;
			//seenct += 1;
			bad.AddForce ((transform.position - player.transform.position) * 0.004f);
		}
		if (isseen && Vector2.Distance (player.transform.position, transform.position) <= 1f) { //start to follow, show text button, if you click
			//love, then she follows but you die if u hit the border, else she'll kill u if you click no. if u die, it turns black and you restart.
			//transform.position = Vector2.MoveTowards(transform.position,player.transform.position, 0.1f*Time.deltaTime);

			bad.velocity = pl.velocity;

		}
	}


}
