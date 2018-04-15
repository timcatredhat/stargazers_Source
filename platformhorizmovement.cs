using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformhorizmovement : MonoBehaviour {
	public float disp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(disp + Mathf.PingPong(2*Time.time, 4), transform.position.y, transform.position.z);
	}
}
