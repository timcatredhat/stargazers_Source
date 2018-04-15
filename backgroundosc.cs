using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundosc : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Mathf.PingPong(0.07f*Time.time, 0.09f), transform.position.y, transform.position.z);
	}
}
