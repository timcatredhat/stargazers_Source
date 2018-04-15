using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameinfo : MonoBehaviour {

	public int kills; //not killable game info and stats
	public bool good;

	void Awake() {
		DontDestroyOnLoad (this);
	}
}