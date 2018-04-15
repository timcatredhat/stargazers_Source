using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;

	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis ("Horizontal");

		if (Input.GetKeyDown (KeyCode.UpArrow) && grounded) { //below takes care of jumping and its velocity
			velocity.y = jumpTakeOffSpeed;
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			if (velocity.y > 0) {
				velocity.y = velocity.y * 0.5f;
			}
		}

		targetVelocity = move * maxSpeed;
	}
}