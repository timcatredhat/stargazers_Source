using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_or_exit : MonoBehaviour {

	public GameObject thang;
	// Use this for initialization
	void Start () {
		StartCoroutine ("Quitt");
	}

	public IEnumerator Quitt() {
		yield return new WaitForSeconds (3);
		Application.Quit ();
	}
		
}
