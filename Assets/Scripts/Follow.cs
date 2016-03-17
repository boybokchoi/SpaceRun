using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public Transform player;

	// Update is called once per frame
	void Update () {
		if (player != null) {
			Vector3 target = player.position;
			target.z = transform.position.z;
			transform.position = target;
		}
	
	}
}
