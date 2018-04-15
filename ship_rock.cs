using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_rock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (-90.0f, 0f, 90.0f + 180.0f * (Mathf.Sin (Time.time * 0.25f)));
	}
}
