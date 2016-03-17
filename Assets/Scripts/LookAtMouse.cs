using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {

	private Vector3 mousePosition;
	private Vector3 playerPosition;
	private float angle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		mousePosition = Input.mousePosition;
		playerPosition = Camera.main.WorldToScreenPoint (transform.position);
		mousePosition.x -= playerPosition.x;
		mousePosition.y -= playerPosition.y;

		angle = Mathf.Atan2 (mousePosition.y, mousePosition.x) * Mathf.Rad2Deg - 90;
		Vector3 rotationVector = new Vector3 (0, 0, angle);
		transform.rotation = Quaternion.Euler (rotationVector);
	
	}
}
