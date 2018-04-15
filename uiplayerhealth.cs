using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiplayerhealth : MonoBehaviour {
	
	void Update () { //updates the player health in the red heart UI thing on screen
		this.GetComponent<Image>().fillAmount = 
			GameObject.FindGameObjectWithTag("Player").GetComponent<player_controller>().phealth * 0.02f;
	}
}
