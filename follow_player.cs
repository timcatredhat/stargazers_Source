using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour {

	private Vector3 playertarg;
	private Transform targ;
	public bool inframe;
	public Rigidbody camrb;
	public bool levelone;
	public bool leveltwo;
	public bool shiftedone; public Vector3 shiftup; public Vector3 shiftdown;
	public int camspeed; 

	public float temp2shift1; public float tempshift1;

	// Use this for initialization
	void Start () {
		camspeed = 8;
		levelone = true;
		leveltwo = false;
		targ = GameObject.FindGameObjectWithTag ("Player").transform;
		inframe = true;
		camrb = GetComponent<Rigidbody> ();
		shiftedone = false;

		tempshift1 = transform.position.y;
		temp2shift1 = tempshift1 + 10.3f;
	}

	void Update (){
		//if (inframe && targ.transform.position.y <= -3) {
		if (targ.GetComponent<player_controller>().dofadeout) {
			camspeed = 900;
		} else if (inframe) {
			camspeed = 7;
		} else if (!inframe) {
			camspeed = 0;
		}
		playertarg = new Vector3 (targ.position.x, transform.position.y, transform.position.z);
		regmove ();
		haltmove ();

		if (targ.transform.position.x >= 4.2f) {
			inframe = true;
			//transform.position = playertarg;
		} 
		if (targ.transform.position.x < 4.2f) {
			inframe = false;
			//camrb.velocity = new Vector3(0,0,0);
		}

//		if (targ.transform.position.y <= 4f) {
//			levelone = true; leveltwo = false;
//		}
//		if (targ.transform.position.y > 4f) {
//			levelone = false; leveltwo = true;
//		}
		if (targ.transform.position.y > 4.54f && targ.transform.position.x > 66.7f) {
			shiftcam1 ();

		}
		if (targ.transform.position.y <= 4.54f && targ.transform.position.x <= 66.7f) {
			shiftcam1down ();
		}
			
	}

	void regmove () {
//		if (inframe && targ.transform.position.y > -3) {
			playertarg = new Vector3 (targ.position.x, transform.position.y, transform.position.z);
			transform.position = Vector3.MoveTowards (transform.position, playertarg, camspeed * Time.deltaTime);
//		} else if (inframe && targ.transform.position.y <= -3){
//			playertarg = new Vector3 (targ.position.x, transform.position.y, transform.position.z);
//			transform.position = playertarg;
//		}
	}

	void haltmove () {
		if (!inframe) {
			camrb.velocity = new Vector3(0,0,0);
		}
	}

	void shiftcam1() {
		
		shiftup = new Vector3 (transform.position.x, temp2shift1, transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, shiftup, 20f * Time.deltaTime);
		//shiftedone = true;
	}

	void shiftcam1down() {
		shiftdown = new Vector3 (transform.position.x, tempshift1, transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, shiftdown, 20f * Time.deltaTime);
		//shiftedone = false;
	}

}
