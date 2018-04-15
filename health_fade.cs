using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_fade : MonoBehaviour {
	public bool osci = true;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("osc", 0, 2.4f);
	}
	
	// Update is called once per frame
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
