using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class control_endgame_script_2 : MonoBehaviour {
	public GameObject info;
	// Use this for initialization
	void Start () {
		info = GameObject.Find ("thang");
		if (info.GetComponent<gameinfo> ().good) {
			Destroy(GameObject.Find("badtext"));
		} else {
			Destroy(GameObject.Find("goodtext"));
			GameObject.Find ("badtext").GetComponent<Text> ().text = "You are a murderer. \nYou are dead. \nYour son is dead.\nKill count: " + info.GetComponent<gameinfo>().kills.ToString() + ".";
		}
	}

	public void gotoend() {
		//SceneManager.LoadScene (6);
		Application.Quit();
	}

	public void gotomenu() {
		info.GetComponent<gameinfo> ().kills = 0;
		SceneManager.LoadScene (0);
	}
}
