using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endgamecontrol : MonoBehaviour {
	public void restartgame() {
		SceneManager.LoadScene (0); //if player wishes to restart
	}
}
