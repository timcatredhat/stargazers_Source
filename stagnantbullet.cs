using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stagnantbullet : MonoBehaviour {

	void Start () {
		Destroy (gameObject, 0.2f); //if bullet is stagnant, destroy it quickly
	}
}
