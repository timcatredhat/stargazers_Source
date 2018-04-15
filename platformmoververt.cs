using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmoververt : MonoBehaviour {
	public float height;
	public bool st = false;
	// Use this for initialization
	void Start () {
		StartCoroutine (randstart ());
	}
	
	// Update is called once per frame
	void Update () {
		if (st) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, Mathf.PingPong (2 * Time.time, 5) + height, gameObject.transform.position.z);
		}
	}

	IEnumerator randstart() {
		yield return new WaitForSeconds (Random.Range (0, 2.2f));
		st = true;
	}
}
