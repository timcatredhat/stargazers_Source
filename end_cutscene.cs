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


	// Use this for initialization
	void Start () {
		fadescreen = GameObject.FindGameObjectWithTag ("fadeinout");
		fadescreen.GetComponent<CanvasGroup> ().alpha = 1;
		dialogue1 = GameObject.FindGameObjectWithTag ("dialogue1");
		d1 = dialogue1.GetComponent<Text>();
		m1 = d1.text;
		d1.text = "";
		StartCoroutine (talkone());

	}
	
	// Update is called once per frame
	void Update () {

		if (!doit) {
			fadescreen.GetComponent<CanvasGroup> ().alpha -= 0.05f;
		}


		if (fadeout1) {
			d1.GetComponent<CanvasGroup> ().alpha -= 0.1f;
		}

		if (doit) {
			fadescreen.GetComponent<CanvasGroup> ().alpha += 0.05f;

		}
	}

	public void load() {
		fadeout1 = true;
		StartCoroutine (end());
	}

	public void load2() {
		fadeout1 = true;
		StartCoroutine (end2());
	}

	public IEnumerator talkone() {

		yield return new WaitForSeconds(0.4f);
	
		foreach (char letter in m1.ToCharArray()) {
			d1.text += letter;
			yield return new WaitForSeconds (0.045f);
		}
	}

	public IEnumerator end() {
		doit = true;
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene (2);
	}

	public IEnumerator end2() {
		doit = true;
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene (3);
	}

}
