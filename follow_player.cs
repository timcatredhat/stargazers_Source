using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour { //this is for the camera view

	private Vector3 playertarg;
	private Transform targ;
	public bool inframe;
	public Rigidbody camrb;
	public bool levelone;
	public bool leveltwo;
	public bool shiftedone; public Vector3 shiftup; public Vector3 shiftdown;
	public int camspeed; 
	public float temp2shift1; public float tempshift1;

	void Start () {
		camspeed = 8;
		levelone = true;
		leveltwo = false;
		targ = GameObject.FindGameObjectWithTag ("Player").transform; //follow the player
		inframe = true;
		camrb = GetComponent<Rigidbody> ();
		shiftedone = false;

		tempshift1 = transform.position.y;
		temp2shift1 = tempshift1 + 10.3f;
	}

	void Update (){
		if (targ.GetComponent<player_controller>().dofadeout) { //if player dies, fade out the screen and restart
			camspeed = 900;
		} else if (inframe) {
			camspeed = 7;
		} else if (!inframe) {
			camspeed = 0;
		}
		playertarg = new Vector3 (targ.position.x, transform.position.y, transform.position.z);

		regmove ();
		haltmove ();

		if (targ.transform.position.x >= 4.2f) { //makes horizontal movement stop if too close to far left of game
			inframe = true;
		} 
		if (targ.transform.position.x < 4.2f) { //if game is at the start, camera can't move further left
			inframe = false;
		}
			
		if (targ.transform.position.y > 4.54f && targ.transform.position.x > 66.7f) { //for when the player goes to 2nd storey
			shiftcam1 ();

		}
		if (targ.transform.position.y <= 4.54f && targ.transform.position.x <= 66.7f) { //for when the player drops from 2nd storey
			shiftcam1down ();
		}
			
	}

	void regmove () {
		playertarg = new Vector3 (targ.position.x, transform.position.y, transform.position.z); //regular follow motion
		transform.position = Vector3.MoveTowards (transform.position, playertarg, camspeed * Time.deltaTime);
	}

	void haltmove () { //if at game start, camera doesn't follow player, it's motionless
		if (!inframe) {
			camrb.velocity = new Vector3(0,0,0);
		}
	}

	void shiftcam1() { //shift camera up
		shiftup = new Vector3 (transform.position.x, temp2shift1, transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, shiftup, 20f * Time.deltaTime);
	}

	void shiftcam1down() { //shift camera down
		shiftdown = new Vector3 (transform.position.x, tempshift1, transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, shiftdown, 20f * Time.deltaTime);
	}
}