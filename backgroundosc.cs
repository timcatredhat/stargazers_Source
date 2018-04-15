using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundosc : MonoBehaviour {
	void Update () { //oscillate the background to make it look trippy
		transform.position = new Vector3(Mathf.PingPong(0.07f*Time.time, 0.09f), transform.position.y, transform.position.z);
	}
}
