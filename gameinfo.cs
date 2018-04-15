using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameinfo : MonoBehaviour {

	public int kills;
	public bool good;

	void Awake() {
		DontDestroyOnLoad (this);
	}

}
