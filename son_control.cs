using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class son_control : MonoBehaviour {
	public GameObject dad;
	public GameObject eyeball, eyeoutline, eyeclosed;
	public Vector3 eyeposrest, eyeposright, eyeposleft, eyeoutlinepos;
	public bool eyerest, eyeleft, eyeright, eyeopen, blinktime, help;
	public float shealth = 10;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("blink", 0, 2.2f);
		InvokeRepeating ("helpswitch", 0, 1.3f);
		eyeball = GameObject.FindGameObjectWithTag ("eyeballson");
		eyeoutline = GameObject.FindGameObjectWithTag ("eyeoutlineson");
		eyeclosed = GameObject.FindGameObjectWithTag ("eyeshutson");
		eyeclosed.GetComponent<Renderer> ().enabled = false;
		eyeposrest = eyeball.transform.position;
		eyeposleft = eyeposrest - new Vector3 (0.4f, 0, 0);
		eyeposright = eyeposrest + new Vector3 (0.4f, 0, 0);

		dad = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		eyeoutlinepos = eyeoutline.transform.position;
		eyeposrest = eyeoutlinepos;
		eyeposleft = eyeposrest - new Vector3 (0.13f, 0, 0);
		eyeposright = eyeposrest + new Vector3 (0.13f, 0, 0);

		if (dad.GetComponent<player_controller>().eyerest) {
			eyeball.transform.position = eyeposrest;
		} else if (dad.GetComponent<player_controller>().eyeleft) {
			eyeball.transform.position = eyeposleft;
		} else if (dad.GetComponent<player_controller>().eyeright) {
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

		if (!dad.GetComponent<player_controller> ().arebuddies) {
			if (help) {
				GameObject.Find ("help").GetComponent<CanvasGroup> ().alpha -= 0.1f;
			} else if (!help) {
				GameObject.Find ("help").GetComponent<CanvasGroup> ().alpha += 0.1f;
			}
		} else {
			GameObject.Find ("help").GetComponent<CanvasGroup> ().alpha = 0;
		}
	}

	void blink() {
		eyeopen = !eyeopen;
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

	void helpswitch() {
		help = !help;
	}

	public void takedamage(float dmg) {
		shealth -= dmg;
	}
}
