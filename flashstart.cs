using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flashstart : MonoBehaviour {
	public bool vd, vd2, notstarted, startanimdone, fo, notblack;
	public GameObject plyr, fadeout, ps; 
	// Use this for initialization
	void Start () {
	//	plyr = GameObject.FindGameObjectWithTag ("Player");
		fadeout = GameObject.FindGameObjectWithTag ("fadeinout");
		ps = GameObject.Find ("Particle System");
		fadeout.GetComponent<CanvasGroup> ().alpha = 0;
	//	plyr.GetComponent<CanvasGroup> ().alpha = 0;
		vd = true; vd2 = true;
		InvokeRepeating ("switcher", 0, 1f);
		notstarted = true;
		startanimdone = false;
		fo = false;
		notblack = true;
	}

	// Update is called once per frame
	void Update () {

		if (fadeout.GetComponent<CanvasGroup> ().alpha == 1) {
			notblack = false;
		}

		if (fo && notblack) {
			fadeout.GetComponent<CanvasGroup> ().alpha += 0.013f;
		}

		if (vd && notstarted) {
			GetComponent<CanvasGroup> ().alpha -= 0.05f;
		} else if (!vd && notstarted) {
			GetComponent<CanvasGroup> ().alpha += 0.05f;
		}

		if (Input.anyKeyDown && notstarted) {
			notstarted = false;
			StartCoroutine ("switcher2");
			StartCoroutine ("startanim");
		}

	}

	void switcher() {
		vd = !vd;
	}

	public IEnumerator switcher2() {
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

	public IEnumerator startanim() {
		yield return new WaitForSeconds (0.8f);
		//plyr.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
		startanimdone = true;
		//yield return new WaitForSeconds (4.5f);
		ps.SetActive (false);
		fo = true;
		yield return new WaitForSeconds (2.1f);
		SceneManager.LoadScene (1);

	}
}
