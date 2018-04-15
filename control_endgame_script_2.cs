using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class control_endgame_script_2 : MonoBehaviour {
	public GameObject info;

	void Start () { //this script is in the case that the dad didn't save his son
		info = GameObject.Find ("thang"); //number of kills is taken from stats
		if (info.GetComponent<gameinfo> ().good) { //if the father showed a good example to his son, this is the end game screen
			Destroy(GameObject.Find("badtext"));
		} else {
			Destroy(GameObject.Find("goodtext")); //if the father showed a bad example to his son, this is the end game screen
			GameObject.Find ("badtext").GetComponent<Text> ().text = 
				"You are a murderer. \nYou are dead. \nYour son is dead.\n" +
				"Kill count: " + info.GetComponent<gameinfo>().kills.ToString() + ".";
		}
	}

	public void gotoend() { //if the player exits
		Application.Quit();
	}

	public void gotomenu() { //if the player restarts
		info.GetComponent<gameinfo> ().kills = 0;
		SceneManager.LoadScene (0);
	}
}
