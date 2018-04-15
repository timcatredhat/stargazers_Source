using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiplayerhealth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Image>().fillAmount = GameObject.FindGameObjectWithTag("Player").GetComponent<player_controller>().phealth * 0.02f;
	}
}
