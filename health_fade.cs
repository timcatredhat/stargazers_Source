using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_fade : MonoBehaviour { //makes the collectable health tokens pulsate on screen
	public bool osci = true;

	void Start () {
		InvokeRepeating ("osc", 0, 2.4f);
	}
	
	void Update () {
		if (osci) {
			gameObject.GetComponent<CanvasGroup> ().alpha -= 0.01f;
		} else if (!osci) {
			gameObject.GetComponent<CanvasGroup> ().alpha += 0.1f;
		}
	}

	public void osc() {
		osci = !osci;
	}
}
