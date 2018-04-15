using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformhorizmovement : MonoBehaviour {
	public float disp;

	void Update () { //for movement of horizontal sliding platforms
		transform.position = new Vector3(disp + Mathf.PingPong(2*Time.time, 4), //for moving platform left and right
			transform.position.y, transform.position.z);
	}
}
