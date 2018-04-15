using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Serialization;

public class player_controller : MonoBehaviour {
	//public Rigidbody rb;
	public GameObject eyeball, eyeoutline, eyeclosed;
	public Vector3 eyeposrest, eyeposright, eyeposleft, eyeoutlinepos;
	public bool eyerest, eyeleft, eyeright, eyeopen, blinktime;
	public int lastdir;

	public int killct = 0;
	public bool canmove = true;
	public Collider currhit;

	public Vector3 moveDirection, groundPos;
	public LayerMask ground;

	public CanvasGroup fadeinout;

	public GameObject backgrounds;
	public bool grounded, isjump;

	public GameObject friend1; public Vector3 friend1startpos; 

	public GameObject[] enemies;
	public GameObject enemy1, enemy0; public Vector3 enemy1startpos, enemy0startpos;
	public GameObject warningflag1; public Vector3 warningflag1pos; public bool youreseen;


	public bool yesc5; public GameObject c5; public GameObject tri5; public Vector3 tri5new;
	public bool yesc4; public GameObject c4; public GameObject tri4; public Vector3 tri4new;
	public bool yesc3; public GameObject c3; public GameObject tri3; public Vector3 tri3new;
	public bool yesc2; public GameObject c2; public GameObject tri2; public Vector3 tri2new;
	public bool yesc1; public GameObject c1; public GameObject tri1; public Vector3 tri1new;


	public int numcoins;
	public bool haskey1; public GameObject key1obj; public bool haskey2; public GameObject key2obj;
	public Vector3 key1pos; public Vector3 key2pos;
	public GameObject key3obj; public bool haskey3;


	public bool dofadeout;
	public bool inajump;

	public GameObject leverone; public GameObject leveroneflipped; public GameObject levertwo; public GameObject levertwoflipped;
	public GameObject leverthree; public GameObject leverthreeflipped; public GameObject leverfour; public GameObject leverfourflipped;
	public int leveroneint; public int levertwoint; public int leverthreeint; public int leverfourint;
	public GameObject slidingwallone; public Vector3 origpos; public Vector3 downpos;
	public GameObject slidingwalltwo; public Vector3 origpos2; public Vector3 downpos2;
	public GameObject slidingwallthree; public Vector3 origpos3; public Vector3 downpos3;
	public GameObject slidingwallfour; public Vector3 origpos4; public Vector3 uppos4;
	public Vector3 origposleverfour, downposleverfour;

	public GameObject block1; public Vector3 block1pos;


	public bool arebuddies;

	public GameObject bullet;

	public float phealth = 50;
	public bool talk1 = false;
	public bool talk1done = false;
	public bool fadeout1 = false;
	public bool talk2 = false;
	public bool talk2done = false;
	public bool fadeout2 = false;
	public bool talk3 = false;
	public bool talk3done = false;
	public bool fadeout3 = false;
	public bool talk4 = false;
	public bool talk4done = false;
	public bool fadeout4 = false;
	public bool talk5 = false;
	public bool talk5done = false;
	public bool fadeout5 = false;
	public GameObject dialogue1, dialogue2, dialogue3, dialogue4, dialogue5, dialogue6, dialogue7, dialogue8, dialogue9, dialogue10;
	public Text d1, d2, d3, d4, d5, d6, d7, d8, d9, d10; public string m1, m2, m3, m4, m5, m6, m7, m8, m9, m10;

	public bool zzz;
	public GameObject gun, usegun;
	public bool hasgun = false;

	public bool enemytouched = false;

	public bool killedron = false, killedjan = false, killedmoe = false, killedskye = false, killedrae = false;
	// Use this for initialization
	public Vector3 ropeplatformloc, ropeplatformlocup;

	public GameObject truck, truck2, upper;
	public Vector3 upperinit, upperafter;
	public bool truckmove, moveupperup = false;

	public bool sonthrown = false;
	public bool goodboy;

	void Start () {


		findclosestplatform ();

		gun = GameObject.Find ("gun");
		usegun = GameObject.FindGameObjectWithTag ("usegun");
		usegun.GetComponent<CanvasGroup> ().alpha = 0;

		Physics.gravity = new Vector3 (0, -70f, 0);

		eyeball = GameObject.FindGameObjectWithTag ("eyeball");
		eyeoutline = GameObject.FindGameObjectWithTag ("eyeoutline");
		eyeclosed = GameObject.FindGameObjectWithTag ("eyeshut");
		eyeclosed.GetComponent<Renderer> ().enabled = false;
		eyeposrest = eyeball.transform.position;
		eyeposleft = eyeposrest - new Vector3 (0.5f, 0, 0);
		eyeposright = eyeposrest + new Vector3 (0.5f, 0, 0);

		groundPos = transform.position; 
		dialogue1 = GameObject.FindGameObjectWithTag ("dialogue1");
		dialogue2 = GameObject.FindGameObjectWithTag ("dialogue2");
		dialogue3 = GameObject.FindGameObjectWithTag ("dialogue3");
		dialogue4 = GameObject.Find("plsdont");

		dialogue5 = GameObject.Find ("goodresp");
		dialogue6 = GameObject.Find ("goodresp2");
		dialogue7 = GameObject.Find ("goodresp3");
		dialogue8 = GameObject.Find ("badresp");
		dialogue9 = GameObject.Find ("badresp2");
		dialogue10 = GameObject.Find ("badresp3");


		d1 = dialogue1.GetComponent<Text>();
		m1 = d1.text;
		d1.text = "";
		d2 = dialogue2.GetComponent<Text> ();
		m2 = d2.text;
		d2.text = "";
		d3 = dialogue3.GetComponent<Text> ();
		m3 = d3.text;
		d3.text = "";
		d4 = dialogue4.GetComponent<Text> ();
		m4 = d4.text;
		d4.text = "";

		d5 = dialogue5.GetComponent<Text> ();
		m5 = d5.text;
		d5.text = "";
		d6 = dialogue6.GetComponent<Text> ();
		m6 = d6.text;
		d6.text = "";
		d7 = dialogue7.GetComponent<Text> ();
		m7 = d7.text;
		d7.text = "";
		d8 = dialogue8.GetComponent<Text> ();
		m8 = d8.text;
		d8.text = "";
		d9 = dialogue9.GetComponent<Text> ();
		m9 = d9.text;
		d9.text = "";
		d10 = dialogue10.GetComponent<Text> ();
		m10 = d10.text;
		d10.text = "";

		inajump = false;
		fadeinout = GameObject.FindGameObjectWithTag ("fadeinout").GetComponent<CanvasGroup> ();
		fadeinout.alpha = 0;

		dofadeout = false;

		friend1 = GameObject.FindGameObjectWithTag ("friend1"); friend1startpos = friend1.transform.position;

		enemies = GameObject.FindGameObjectsWithTag ("enemy");
		enemy0 = GameObject.Find("enemy0"); enemy0startpos = enemy0.transform.position;
		enemy1 = GameObject.Find("enemy1"); enemy1startpos = enemy1.transform.position;

		truck = GameObject.Find ("truck"); truckmove = false; 
		truck2 = GameObject.Find ("truck2");
		upper = GameObject.Find ("upper");
		upperinit = upper.transform.position;
		upperafter = upperinit + new Vector3 (0, 2.61f, 0);

		ropeplatformloc = GameObject.Find ("ropeplatform").transform.position;
		ropeplatformlocup = GameObject.Find ("ropeplatform").transform.position + new Vector3 (0, 1.9f, 0);
		GameObject.Find ("ropeplatform").transform.position = ropeplatformlocup;

		yesc5 = false; yesc4 = false; yesc3 = false; yesc2 = false; yesc1 = false;
		c1 = GameObject.FindGameObjectWithTag ("c1"); tri1 = GameObject.FindGameObjectWithTag ("tri1"); tri1new = new Vector3 (tri1.transform.position.x, tri1.transform.position.y - 2.1f, tri1.transform.position.z);
		c2 = GameObject.FindGameObjectWithTag ("c2"); tri2 = GameObject.FindGameObjectWithTag ("tri2"); tri2new = new Vector3 (tri2.transform.position.x, tri2.transform.position.y - 2.1f, tri2.transform.position.z);
		c3 = GameObject.FindGameObjectWithTag ("c3"); tri3 = GameObject.FindGameObjectWithTag ("tri3"); tri3new = new Vector3 (tri3.transform.position.x, tri3.transform.position.y - 2.1f, tri3.transform.position.z);
		//c4 = GameObject.FindGameObjectWithTag ("c4"); tri4 = GameObject.FindGameObjectWithTag ("tri4"); tri4new = new Vector3 (tri4.transform.position.x, tri4.transform.position.y - 2.1f, tri4.transform.position.z);
		//c5 = GameObject.FindGameObjectWithTag ("c5"); tri5 = GameObject.FindGameObjectWithTag ("tri5"); tri5new = new Vector3 (tri5.transform.position.x, tri5.transform.position.y - 2.1f, tri5.transform.position.z);

		numcoins = 0;
		key1obj = GameObject.FindGameObjectWithTag ("key1"); haskey1 = false;
		key2obj = GameObject.FindGameObjectWithTag ("key2"); haskey2 = false;
		key3obj = GameObject.FindGameObjectWithTag ("key3"); haskey3 = false;
		key1pos = key1obj.transform.position; key2pos = key2obj.transform.position;

		backgrounds = GameObject.FindGameObjectWithTag ("backgrounds");
		grounded = false;


		leverone = GameObject.FindGameObjectWithTag ("lever1"); leveroneint = 0;
		levertwo = GameObject.FindGameObjectWithTag ("lever2"); levertwoint = 0;
		leverthree = GameObject.FindGameObjectWithTag ("lever3"); leverthreeint = 0;
		leverfour = GameObject.FindGameObjectWithTag ("lever4"); leverfourint = 0;

		leveroneflipped = GameObject.FindGameObjectWithTag ("lever1flipped"); leveroneflipped.SetActive (false);
		levertwoflipped = GameObject.FindGameObjectWithTag ("lever2flipped"); levertwoflipped.SetActive (false); 
		leverthreeflipped = GameObject.FindGameObjectWithTag ("lever3flipped"); leverthreeflipped.SetActive (false);
		leverfourflipped = GameObject.FindGameObjectWithTag ("lever4flipped"); leverfourflipped.SetActive (false);
		origposleverfour = GameObject.Find ("lever4").transform.position;
		downposleverfour = GameObject.Find ("lever4").transform.position - new Vector3 (0, 30, 0);

		slidingwallone = GameObject.FindGameObjectWithTag ("sw1"); slidingwallone.SetActive (true); 
		slidingwalltwo = GameObject.FindGameObjectWithTag ("sw2"); slidingwalltwo.SetActive (true);
		slidingwallthree = GameObject.FindGameObjectWithTag ("sw3"); slidingwallthree.SetActive (true);
		slidingwallfour = GameObject.FindGameObjectWithTag ("sw4"); slidingwallfour.SetActive (true);
		origpos = slidingwallone.transform.position; downpos = slidingwallone.transform.position - new Vector3 (0, 40, 0);
		origpos2 = slidingwalltwo.transform.position; downpos2 = slidingwalltwo.transform.position - new Vector3 (0, 40, 0); 
		origpos3 = slidingwallthree.transform.position; downpos3 = slidingwallthree.transform.position - new Vector3 (0, 40, 0);
		origpos4 = slidingwallfour.transform.position - new Vector3 (0, 40, 0); uppos4 = origpos4 + new Vector3 (0, 40, 0); 


		block1 = GameObject.FindGameObjectWithTag ("block1"); block1pos = block1.transform.position;


		arebuddies = false;

		InvokeRepeating ("blink", 0, 3);
		InvokeRepeating ("zzzswitch", 0, 1.5f);
	}



	// Update is called once per frame
	void Update () {

		GameObject.Find ("thang").GetComponent<gameinfo> ().kills = killct;
		GameObject.Find ("thang").GetComponent<gameinfo> ().good = goodboy;


		if (GameObject.Find ("throwson") != null) {
			if (GameObject.Find ("throwson").GetComponent<CanvasGroup> ().alpha == 1 && Input.GetKeyDown (KeyCode.R)) {
				sonthrown = true;
				friend1.GetComponent<Rigidbody2D> ().isKinematic = false;
				friend1.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (17, 26f), ForceMode2D.Impulse);
				Destroy (GameObject.Find ("throwson"));
			}
		}

		if (truckmove) {
			truck.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.4f, 0);
		}

		if (moveupperup) {
			upper.transform.position = upperafter;
		}

		if (Vector3.Distance (gameObject.transform.position, GameObject.Find ("enemy03").transform.position) <= 6) {
			if (GameObject.Find ("throwson") != null) {
				GameObject.Find ("throwson").GetComponent<CanvasGroup> ().alpha = 1;
			}
		} else {
			if (GameObject.Find ("throwson") != null) {
				GameObject.Find ("throwson").GetComponent<CanvasGroup> ().alpha = 0;
			}
		}

		if (killedron && GameObject.Find ("youkilledron") != null) {
			GameObject.Find ("youkilledron").GetComponent<CanvasGroup> ().alpha += 0.1f;
			Destroy (GameObject.Find ("youkilledron"), 8);
		}
		if (killedjan && GameObject.Find ("youkilledjan") != null) {
			GameObject.Find ("youkilledjan").GetComponent<CanvasGroup> ().alpha += 0.1f;
			Destroy (GameObject.Find ("youkilledjan"), 8);
		}
		if (killedmoe && GameObject.Find ("youkilledmoe") != null) {
			GameObject.Find ("youkilledmoe").GetComponent<CanvasGroup> ().alpha += 0.1f;
			Destroy (GameObject.Find ("youkilledmoe"), 8);
		}
		if (killedrae && GameObject.Find ("youkilledrae") != null) {
			GameObject.Find ("youkilledrae").GetComponent<CanvasGroup> ().alpha += 0.1f;
			Destroy (GameObject.Find ("youkilledrae"), 8);
		}
		if (killedskye && GameObject.Find ("youkilledskye") != null) {
			GameObject.Find ("youkilledskye").GetComponent<CanvasGroup> ().alpha += 0.1f;
			Destroy (GameObject.Find ("youkilledskye"), 8);
		}

		GameObject.Find ("skullnum").GetComponent<Text> ().text = killct.ToString ();

		GameObject.Find ("fadein").GetComponent<CanvasGroup> ().alpha -= 0.05f;

		if (zzz) {
			GameObject.FindGameObjectWithTag ("zzz").GetComponent<CanvasGroup> ().alpha -= 0.1f;
		} else {
			GameObject.FindGameObjectWithTag ("zzz").GetComponent<CanvasGroup> ().alpha += 0.1f;

		}

		if (Mathf.Abs (transform.position.x - gun.transform.position.x) <= 2) {
			usegun.GetComponent<CanvasGroup> ().alpha = 1;
			if (Input.GetKeyDown (KeyCode.X)) {
				hasgun = true;
				gun.transform.position = gun.transform.position + new Vector3 (100, 100, 100);
			}
		} else {
			usegun.GetComponent<CanvasGroup> ().alpha = 0;
		}

		findclosestplatform ();
		checkendgame ();
		if (phealth <= 0 && !talk5done) {
			SceneManager.LoadScene (3);
		}

		eyeoutlinepos = eyeoutline.transform.position;
		eyeposrest = eyeoutlinepos;
		eyeposleft = eyeposrest - new Vector3 (0.13f, 0, 0);
		eyeposright = eyeposrest + new Vector3 (0.13f, 0, 0);

		if (eyerest) {
			eyeball.transform.position = eyeposrest;
		} else if (eyeleft) {
			eyeball.transform.position = eyeposleft;
		} else if (eyeright) {
			eyeball.transform.position = eyeposright;
		}

		if (eyeopen) {
			eyeball.GetComponent<Renderer> ().enabled = true;
			eyeoutline.GetComponent<Renderer> ().enabled = true;
			eyeclosed.GetComponent<Renderer> ().enabled = false;
			blinktime = true;
		} else if (!eyeopen) {
			StartCoroutine ("doblink");
		}

		if (talk1) {
		//	Time.timeScale = 0;
			grounded = false;
			StartCoroutine ("talkone");
		}

		if (talk3) {
			//	Time.timeScale = 0;
			grounded = false;
			StartCoroutine ("talkthree");
		}

		if (talk2) {
			grounded = false;
			StartCoroutine ("talktwo");
		}

		if (talk4) {
			grounded = false;
			StartCoroutine ("talkfour");
		}

		if (talk5) {
			grounded = false;
			if (GameObject.Find ("enemy2") != null) {
				goodboy = true;
				StartCoroutine ("talkfive");
			} else {
				goodboy = false;
				StartCoroutine ("talksix");
			}
		}

		if (talk5done) {
			StartCoroutine ("ending");
		}

		if (fadeout1) {
			d1.GetComponent<CanvasGroup> ().alpha -= 0.1f;
		}

		if (fadeout2) {
			d2.GetComponent<CanvasGroup> ().alpha -= 0.1f;
		}

		if (fadeout3) {
			d3.GetComponent<CanvasGroup> ().alpha -= 0.1f;
		}

		if (fadeout4) {
			d4.GetComponent<CanvasGroup> ().alpha -= 0.1f;
		}
//		friendpopup.alpha = 0;

		if (dofadeout) {
			//fadeinout.alpha = Mathf.PingPong(Time.time, 1) / 1;;
			//fadeinout.alpha = 1;
			fadeinout.alpha -= Time.deltaTime * 1.6f;
			Invoke ("endfade", 0.3f);
			//dofadeout = false;
		} else{
			dofadeout = false;
		}



		//enemies below




		//keys below

		if (!haskey1 && Vector3.Distance (transform.position, key1obj.transform.position) <= 1) {
			haskey1 = true;
			key1obj.SetActive (false);
			if (phealth <= 45) {
				phealth += 5;
			} else {
				phealth = 50;
			}
		}

		if (!haskey2 && Vector3.Distance (transform.position, key2obj.transform.position) <= 1) {
			haskey2 = true;
			key2obj.SetActive (false);
			if (phealth <= 45) {
				phealth += 5;
			} else {
				phealth = 50;
			}
		}

		if (!haskey3 && Vector3.Distance (transform.position, key3obj.transform.position) <= 1) {
			haskey3 = true;
			key3obj.SetActive (false);
			if (phealth <= 45) {
				phealth += 5;
			} else {
				phealth = 50;
			}
		}


	

			//keys above

		//flags below

		if (yesc1) {
			flagonedown ();
		}

		if (yesc2) {
			flagtwodown ();
		}

		if (yesc3) {
			flagthreedown ();
		}

		if (Mathf.Abs(transform.position.x - c1.transform.position.x) <= 1.3f && Mathf.Abs(transform.position.y - c1.transform.position.y) <= 1.3f) {
			yesc1 = true;
		}

		if (Mathf.Abs(transform.position.x - c2.transform.position.x) <= 1.3f && Mathf.Abs(transform.position.y - c2.transform.position.y) <= 1.3f) {
			yesc2 = true; yesc1 = false;
		}

		if (Mathf.Abs(transform.position.x - c3.transform.position.x) <= 1.3f && Mathf.Abs(transform.position.y - c3.transform.position.y) <= 1.3f) {
			yesc3 = true; yesc2 = false; yesc1 = false;
		}

		shootmissile ();

//
//
		if (canmove) {
			if (Input.GetKey (KeyCode.LeftArrow)) { 
				transform.Translate (Vector3.left * 7 * Time.deltaTime);
				eyeleft = true;
				eyeright = false;
				eyerest = false;
				lastdir = 0;
				//eyeball.transform.position = eyeposleft;
			} else if (Input.GetKey (KeyCode.RightArrow)) { 
				eyeright = true;
				eyeleft = false;
				eyerest = false;
				transform.Translate (Vector3.right * 7 * Time.deltaTime);
				lastdir = 1;
				//eyeball.transform.position = eyeposright;
				//moveDirection += Vector3.right * 1;
				//transform.position = Vector3.Lerp(transform.position, moveDirection, 0.5f * Time.deltaTime);
			} 
			else {
				eyerest = true;
				eyeright = false;
				eyeleft = false;
				//eyeball.transform.position = eyeposrest;
			}
		}else {
				eyerest = true;
			eyeright = false;
			eyeleft = false;
				//eyeball.transform.position = eyeposrest;
			}


			
		// CHOOSE IF YOU'RE FRIENDS!
		if (!arebuddies && Vector3.Distance(transform.position, friend1.transform.position) <= 2f) {
			//make button appear where he says he's so glad you came to same him. you click and you're friends.
			talk2 = true;
		}

		if (arebuddies && !sonthrown) {
			//friend1.transform.position = this.transform.position - Vector3.left * 3;
			var playertarg = new Vector3 (this.transform.position.x, this.transform.position.y, friend1.transform.position.z);
			friend1.transform.position = playertarg + Vector3.up * 0.83f;

		}

		//------------


		//block1.GetComponent<Rigidbody> ().velocity = new Vector3 (0, -5, 0);


		//LEVERS BELOW  
		if (Input.GetKeyDown(KeyCode.R) && Vector3.Distance (transform.position, leverone.transform.position) <= 2) {
			leveroneint += 1;
			if (leveroneint % 2 != 0) {
				leveroneflipped.SetActive (true); leverone.SetActive (false);
			}
			else if (leveroneint % 2 == 0) {
				leveroneflipped.SetActive (false); leverone.SetActive (true); 
			}
		}

		if (leveroneint % 2 == 0) {
			slidingwallone.transform.position = origpos;
		}
		else if (leveroneint % 2 != 0) {
			slidingwallone.transform.position = downpos;
		}
			
		//-----------------

		if (Input.GetKeyDown(KeyCode.R) && Vector3.Distance (transform.position, levertwo.transform.position) <= 2) {
			levertwoint += 1;
			if (levertwoint % 2 != 0) {
				levertwoflipped.SetActive (true); levertwo.SetActive (false);
			}
			else if (levertwoint % 2 == 0) {
				levertwoflipped.SetActive (false); levertwo.SetActive (true); 
			}
		}

		if (levertwoint % 2 == 0) {
			slidingwalltwo.transform.position = origpos2;
		}
		else if (levertwoint % 2 != 0) {
			slidingwalltwo.transform.position = downpos2;
		}

		// ---------------

		if (Input.GetKeyDown(KeyCode.R) && Vector3.Distance (transform.position, leverthree.transform.position) <= 2) {
			leverthreeint += 1;
			if (leverthreeint % 2 != 0) {
				leverthreeflipped.SetActive (true); leverthree.SetActive (false);
			}
			else if (leverthreeint % 2 == 0) {
				leverthreeflipped.SetActive (false); leverthree.SetActive (true); 
			}
		}

		if (leverthreeint % 2 == 0) {
			slidingwallthree.transform.position = origpos3;
			slidingwallfour.transform.position = origpos4;
			GameObject.Find("lever4").transform.position = downposleverfour;
		}
		else if (leverthreeint % 2 != 0) {
			slidingwallthree.transform.position = downpos3;
			slidingwallfour.transform.position = uppos4;
			GameObject.Find("lever4").transform.position = origposleverfour;
		}

		// ------------

		if (Input.GetKeyDown(KeyCode.R) && Vector3.Distance (transform.position, leverfour.transform.position) <= 2) {
			leverfourint += 1;
			if (leverfourint % 2 != 0) {
				leverfourflipped.SetActive (true); leverfour.SetActive (false);
			}
			else if (leverfourint % 2 == 0) {
				leverfourflipped.SetActive (false); leverfour.SetActive (true); 
			}
		}

		if (leverfourint % 2 != 0) {
			GameObject.Find ("ropeplatform").transform.position = Vector3.Lerp(GameObject.Find ("ropeplatform").transform.position, ropeplatformloc, 2 * Time.deltaTime);
		}
		else if (leverfourint % 2 == 0) {
			GameObject.Find ("ropeplatform").transform.position = Vector3.Lerp(GameObject.Find ("ropeplatform").transform.position, ropeplatformlocup, 2 * Time.deltaTime);
		}
	}
		





	//ISGROUNDED?	
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "ground" && other.gameObject.name != "stat4trig") {
			grounded = true;
		}
		if (other.gameObject.name == "stat4trig" && !talk1done) {
			grounded = true;
			talk1 = true;
		}
		if (other.gameObject.name == "stat10" && !talk3done) {
			grounded = true;
			talk3 = true;
		}
		if (other.gameObject.name == "pls" && !talk4done) {
			grounded = true;
			talk4 = true;
		}
		if (other.gameObject.name == "momentoftruth" && !talk5done) {
			grounded = true;
			talk5 = true;
		}
		if (other.gameObject.tag == "moving") {
			grounded = true;
			transform.parent = other.transform;
			//transform.position = new Vector2(transform.position.x, other.transform.position.y + 3);
			transform.rotation = Quaternion.identity;
		}
		 if (other.gameObject.tag == "slanted") {
			grounded = true;
			transform.rotation = other.transform.rotation;
		}
	}

	void OnCollisionStay2D(Collision2D other) {
		if (other.gameObject.tag == "ground") {
			grounded = true;
		}
		if (other.gameObject.tag == "moving") {
			grounded = true;
			transform.parent = other.transform;
			//transform.rotation = Quaternion.identity;
		}
		 if (other.gameObject.tag == "slanted") {
			grounded = true;
			transform.rotation = other.transform.rotation;
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.tag == "ground") {
			grounded = false;
		}
		if (other.gameObject.tag == "moving") {
			grounded = false;
			transform.parent = null;
			//transform.rotation = Quaternion.identity;
		}
		 if (other.gameObject.tag == "slanted") {
			grounded = false;
			transform.rotation = Quaternion.identity;
		}
	}





	//CHECKING ENDGAME BELOW
	void checkendgame() {
		if (!talk5done && (enemytouched || transform.position.y <= -7)) {
			//phealth = 50;
			dofadeout = true;
			fadeinout.alpha = 1;

			enemytouched = false;
			//	d1.text = "";
			//talk1 = true;
			//	talk1done = false;
//			friend1.transform.position = friend1startpos; 
//			friend1.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0); 
			if (enemy0.GetComponent<enemyhealth> ().gethealth () > 0) {
				enemy0.transform.position = enemy0startpos;
			}
			if (enemy1 != null && yesc2) {
				if (enemy1.GetComponent<enemyhealth> ().gethealth () > 0) {
					enemy1.transform.position = enemy1startpos;
					enemy1.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
					enemy1.GetComponent<enemy_attack> ().ready = false;
					enemy1.GetComponent<enemy_attack> ().tofollow = false;
					enemy1.GetComponent<enemy_follow> ().chaseison = false;


				}
			}
			leverfourint = 4;
			leverfourflipped.SetActive (false); leverfour.SetActive (true); 


			//	youreseen = false;

			block1.transform.position = block1pos; 

			if (yesc5) {
				transform.position = c5.transform.position; 
			} else if (yesc4) {
				transform.position = c4.transform.position; 
			} else if (yesc3) {
				transform.position = c3.transform.position; 
			} else if (yesc2) {
				transform.position = c2.transform.position - new Vector3 (0.4f, 0, 0); 
				transform.rotation = Quaternion.identity;

				//rb.velocity = new Vector3 (0, 0, 0);

			} else if (yesc1) {
				transform.position = c1.transform.position - new Vector3 (1.4f, 0, 0); 
				transform.rotation = Quaternion.identity;
				//rb.velocity = new Vector3 (0, 0, 0);

			}

		} else if (talk5done && (enemytouched || transform.position.y <= -7 || phealth <= 0 || Vector3.Distance(transform.position, truck.transform.position) <= 2.4f || Vector3.Distance(transform.position, truck2.transform.position) <= 2.4f)) {
			dofadeout = true;
			fadeinout.alpha = 1;
			if (sonthrown) {
				SceneManager.LoadScene (4);
			} else if (!sonthrown) {
				SceneManager.LoadScene (5);
			}
			//if pressed r then go to scene blah
			//if not pressed r then go to scene blah
		}
	}

	void endfade() {
		dofadeout = false;
		fadeinout.alpha = 0;
	}

	void flagonedown() {
		tri1.transform.position = Vector3.MoveTowards (tri1.transform.position, tri1new, 7 * Time.deltaTime);
	}

	void flagtwodown() {
		tri2.transform.position = Vector3.MoveTowards (tri2.transform.position, tri2new, 7 * Time.deltaTime);
	}

	void flagthreedown() {
		tri3.transform.position = Vector3.MoveTowards (tri3.transform.position, tri3new, 7 * Time.deltaTime);
	}


	void findclosestplatform() {
		Collider[] allhits = Physics.OverlapSphere (transform.position, 10);
		foreach (Collider i in allhits) {
			if (i.transform.position.y <= transform.position.y && i.tag != "Player") {
				currhit = i;
				print (currhit.transform.position.y);
			} 
		}
	}

	void shootmissile() {
		if (Input.GetKeyDown (KeyCode.X) && canmove && hasgun) {
			GameObject bulletclone = Instantiate (bullet, transform.position, transform.rotation);
		}
			
	}

	void blink() {
		eyeopen = !eyeopen;
	}

	void zzzswitch() {
		zzz = !zzz;
	}

	public void takedamage(float dmg) {
		phealth -= dmg;
	}

	public IEnumerator talkone() {
		talk1 = false;
		canmove = false;
		GetComponent<PlayerPlatformerController> ().enabled = false;
		if (!talk1done) {
			foreach (char letter in m1.ToCharArray()) {
				d1.text += letter;
				yield return new WaitForSeconds (0.045f);
			}
		}
		talk1done = true;
		GetComponent<PlayerPlatformerController> ().enabled = true;
		canmove = true;
		yield return new WaitForSeconds (2);

		fadeout1 = true;

	}

	public IEnumerator talkthree() {
		talk3 = false;
		canmove = false;
		GetComponent<PlayerPlatformerController> ().enabled = false;
		if (!talk3done) {
			foreach (char letter in m3.ToCharArray()) {
				d3.text += letter;
				yield return new WaitForSeconds (0.045f);
			}
		}
		talk3done = true;
		GetComponent<PlayerPlatformerController> ().enabled = true;
		canmove = true;
		yield return new WaitForSeconds (2);

		fadeout3 = true;

	}

	public IEnumerator talktwo() {
		arebuddies = true;

		talk2 = false;
		canmove = false;
		GetComponent<PlayerPlatformerController> ().enabled = false;
		if (!talk2done) {
			foreach (char letter in m2.ToCharArray()) {
				d2.text += letter;
				yield return new WaitForSeconds (0.045f);
			}
		}
		talk2done = true;
		GetComponent<PlayerPlatformerController> ().enabled = true;
		canmove = true;
		yield return new WaitForSeconds (2.3f);

		fadeout2 = true;
	}

	public IEnumerator talkfour() {
		talk4 = false;
		canmove = false;
		GetComponent<PlayerPlatformerController> ().enabled = false;
		if (!talk4done) {
			foreach (char letter in m4.ToCharArray()) {
				d4.text += letter;
				yield return new WaitForSeconds (0.045f);
			}
		}
		talk4done = true;
		GetComponent<PlayerPlatformerController> ().enabled = true;
		canmove = true;
		yield return new WaitForSeconds (5.4f);

		fadeout4 = true;

	}

	public IEnumerator talkfive() {

		//good
		talk5 = false;
		canmove = false;
		GetComponent<PlayerPlatformerController> ().enabled = false;
		if (!talk5done) {
			foreach (char letter in m5.ToCharArray()) {
				d5.text += letter;
				yield return new WaitForSeconds (0.045f);
			}
			yield return new WaitForSeconds (5);
			Destroy (dialogue5);
			foreach (char letter in m6.ToCharArray()) {
				d6.text += letter;
				yield return new WaitForSeconds (0.045f);
			}
			yield return new WaitForSeconds (5);
			Destroy (dialogue6);
			foreach (char letter in m7.ToCharArray()) {
				d7.text += letter;
				yield return new WaitForSeconds (0.045f);
			}
			yield return new WaitForSeconds (5f);

			Destroy (dialogue7);
		}
		talk5done = true;
		GetComponent<PlayerPlatformerController> ().enabled = true;
		canmove = true;

		//fadeout4 = true;

	}

	public IEnumerator talksix() {

		//bad
		talk5 = false;
		canmove = false;
		GetComponent<PlayerPlatformerController> ().enabled = false;
		if (!talk5done) {
			foreach (char letter in m8.ToCharArray()) {
				d8.text += letter;
				yield return new WaitForSeconds (0.045f);
			}
			yield return new WaitForSeconds (5);
			Destroy (dialogue8);
			foreach (char letter in m9.ToCharArray()) {
				d9.text += letter;
				yield return new WaitForSeconds (0.045f);
			}
			yield return new WaitForSeconds (5);
			Destroy (dialogue9);
			foreach (char letter in m10.ToCharArray()) {
				d10.text += letter;
				yield return new WaitForSeconds (0.045f);
			}
			yield return new WaitForSeconds (5f);

			Destroy (dialogue10);
		}
		talk5done = true;
		GetComponent<PlayerPlatformerController> ().enabled = true;
		canmove = true;

		//fadeout4 = true;

	}

	public IEnumerator ending() {
		yield return new WaitForSeconds (2.3f);
		moveupperup = true;
		yield return new WaitForSeconds (2f);
		truckmove = true;
	}


	public IEnumerator doblink() {
		if (blinktime) {
			eyeball.GetComponent<Renderer> ().enabled = false;
			eyeoutline.GetComponent<Renderer> ().enabled = false;
			eyeclosed.GetComponent<Renderer> ().enabled = true;
			yield return new WaitForSeconds (0.1f);
			eyeball.GetComponent<Renderer> ().enabled = true;
			eyeoutline.GetComponent<Renderer> ().enabled = true;
			eyeclosed.GetComponent<Renderer> ().enabled = false;
		}
		blinktime = false;
	}


}
