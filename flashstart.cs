using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flashstart : MonoBehaviour {
	public bool vd, vd2, notstarted, startanimdone, fo, notblack;
	public GameObject plyr, fadeout, ps; 

	void Start () {
		fadeout = GameObject.FindGameObjectWithTag ("fadeinout");
		ps = GameObject.Find ("Particle System");
		fadeout.GetComponent<CanvasGroup> ().alpha = 0;
		vd = true; vd2 = true;
		InvokeRepeating ("switcher", 0, 1f);
		notstarted = true;
		startanimdone = false;
		fo = false;
		notblack = true;
	}

	void Update () {

		if (fadeout.GetComponent<CanvasGroup> ().alpha == 1) { //prompt text fully visible at start
			notblack = false;
		}

		if (fo && notblack) {
			fadeout.GetComponent<CanvasGroup> ().alpha += 0.013f; //fade out screen when game starts
		}

		if (vd && notstarted) {
			GetComponent<CanvasGroup> ().alpha -= 0.05f; //makes title pulsate
		} else if (!vd && notstarted) {
			GetComponent<CanvasGroup> ().alpha += 0.05f;
		}

		if (Input.anyKeyDown && notstarted) { //game start prompted by player input
			notstarted = false;
			StartCoroutine ("switcher2");
			StartCoroutine ("startanim");
		}
	}

	void switcher() { //makes title pulsate
		vd = !vd;
	}

	public IEnumerator switcher2() { //makes the start text flash when game begins
		GetComponent<CanvasGroup> ().alpha = 1;
		yield return new WaitForSeconds (0.2f);
		GetComponent<CanvasGroup> ().alpha = 0;
		yield return new WaitForSeconds (0.2f); 
		GetComponent<CanvasGroup> ().alpha = 1;
		yield return new WaitForSeconds (0.2f); 
		GetComponent<CanvasGroup> ().alpha = 0;
		yield return new WaitForSeconds (0.2f); 
		GetComponent<CanvasGroup> ().alpha = 1;
	}

	public IEnumerator startanim() { //heads to first cutscene when game begins
		yield return new WaitForSeconds (0.8f);
		startanimdone = true;
		ps.SetActive (false);
		fo = true;
		yield return new WaitForSeconds (2.1f);
		SceneManager.LoadScene (1);

	}
}
