using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class control_endgame_screen : MonoBehaviour {
	public GameObject info;

	void Start () {//this script is in the case that the dad saved his kid
		info = GameObject.Find ("thang"); //number of kills is taken from stats
		if (info.GetComponent<gameinfo> ().good) { //if the father showed a good example to his son, this is the end game screen
			Destroy(GameObject.Find("badtext"));
		} else {
			Destroy(GameObject.Find("goodtext")); //if the father showed a bad example to his son, this is the end game screen
			GameObject.Find ("badtext").GetComponent<Text> ().text = 
				"March 21, 4924\n\nIt's been exactly a year since my dad " +
				"gave his life for my freedom. He took " + info.GetComponent<gameinfo>().kills.ToString() + 
				" down with him that fateful day. I hate those who took his life." +
				" \nI was spared to take revenge... someday.\n\nn.p";
		}
	}

	public void gotoend() {
		Application.Quit(); //if the player exits
	}

	public void gotomenu() { //if the player restarts
		info.GetComponent<gameinfo> ().kills = 0;
		SceneManager.LoadScene (0);
	}
}
