using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_follow : MonoBehaviour {
	private Vector3 playertarg;
	private Transform targ;


	// Use this for initialization
	void Start () {
		targ = GameObject.FindGameObjectWithTag ("Player").transform;

	}

	void Update ()
	{
		playertarg = new Vector3 (transform.position.x, targ.position.y+7.5f, transform.position.z);
		transform.position = playertarg;
	}
}
