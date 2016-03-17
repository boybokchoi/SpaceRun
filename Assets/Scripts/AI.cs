using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	public float rotSpeed = 40f;
	float counter;

	Transform player;

	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;

		if (counter >= 15) {
			counter = 0f;
			rotSpeed += 10;
		}

		if (player == null) {
			//Locate player object
			GameObject go = GameObject.FindWithTag("Player");

			if (go != null) {
				player = go.transform;
			}
		}


		// Could not find player, end function
		if (player == null)
			return;

		//Face player
		Vector3 direction = player.position - transform.position;
		direction.Normalize(); //(-1,0,0)

		//find the angle to face the player
		float zAngle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg - 90;

		Quaternion newRot = Quaternion.Euler (0, 0, zAngle);

		transform.rotation = Quaternion.RotateTowards (transform.rotation, newRot, rotSpeed*Time.deltaTime);
	}
}
