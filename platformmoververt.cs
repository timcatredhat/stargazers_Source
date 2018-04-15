using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmoververt : MonoBehaviour {
	public float height;
	public bool st = false;

	void Start () {
		StartCoroutine (randstart ()); //for moving the vertical sliding platforms
	}
	
	void Update () {
		if (st) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, //start oscillating platform up and down
				Mathf.PingPong (2 * Time.time, 5) + height, gameObject.transform.position.z);
		}
	}

	IEnumerator randstart() { //so that all vertical platforms aren't completely synced
		yield return new WaitForSeconds (Random.Range (0, 2.2f));
		st = true;
	}
}
