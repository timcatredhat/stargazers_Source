using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_or_exit : MonoBehaviour {

	public GameObject thang;

	void Start () {
		StartCoroutine ("Quitt"); //if player wishes to quit the game
	}

	public IEnumerator Quitt() {
		yield return new WaitForSeconds (3);
		Application.Quit ();
	}
		
}
