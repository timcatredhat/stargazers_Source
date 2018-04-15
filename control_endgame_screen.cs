using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class control_endgame_screen : MonoBehaviour {
	public GameObject info;
	// Use this for initialization
	void Start () {
		info = GameObject.Find ("thang");
		if (info.GetComponent<gameinfo> ().good) {
			Destroy(GameObject.Find("badtext"));
		} else {
			Destroy(GameObject.Find("goodtext"));
			GameObject.Find ("badtext").GetComponent<Text> ().text = "March 21, 4924\n\nIt's been exactly a year since my dad gave his life for my freedom. He took " + info.GetComponent<gameinfo>().kills.ToString() + " down with him that fateful day. I hate those who took his life. \nI was spared to take revenge... someday.\n\nn.p";
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
