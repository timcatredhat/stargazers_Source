using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class end_cutscene : MonoBehaviour {
	public Text d1; public string m1;
	public bool fadeout1, doit = false;
	public GameObject dialogue1;
	public GameObject fadescreen;

	void Start () {
		fadescreen = GameObject.FindGameObjectWithTag ("fadeinout");
		fadescreen.GetComponent<CanvasGroup> ().alpha = 1;
		dialogue1 = GameObject.FindGameObjectWithTag ("dialogue1");
		d1 = dialogue1.GetComponent<Text>();
		m1 = d1.text;
		d1.text = "";
		StartCoroutine (talkone());
	}
	
	void Update () {

		if (!doit) {
			fadescreen.GetComponent<CanvasGroup> ().alpha -= 0.05f; //fading out
		}

		if (fadeout1) {
			d1.GetComponent<CanvasGroup> ().alpha -= 0.1f;
		}

		if (doit) {
			fadescreen.GetComponent<CanvasGroup> ().alpha += 0.05f; //fading in
		}
	}

	public void load() { //if you're at the first cutscene
		fadeout1 = true;
		StartCoroutine (end());
	}

	public void load2() { //if you're at the second cutscene
		fadeout1 = true;
		StartCoroutine (end2());
	}

	public IEnumerator talkone() {

		yield return new WaitForSeconds(0.4f);
	
		foreach (char letter in m1.ToCharArray()) { //types out the letters on the screen animated
			d1.text += letter;
			yield return new WaitForSeconds (0.045f);
		}
	}

	public IEnumerator end() { //if you're at the first cutscene and wish to go to the next (button controlled)
		doit = true;
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene (2);
	}

	public IEnumerator end2() { //if you're at the second cutscene and wish to start the game (button controlled)
		doit = true;
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene (3);
	}
}