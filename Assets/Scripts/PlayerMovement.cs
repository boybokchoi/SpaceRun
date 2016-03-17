using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Vector3 pos;
	Vector3 vel;
	Quaternion rot;
	public float speed = 3f;
	public float rotSpeed = 150f;
	float zRotation;

	float playerSize = 0.45f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Get the current position and increase when movement
		//buttons are pressed
		/*rot = transform.rotation;
		zRotation = rot.eulerAngles.z;
		zRotation -= Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0, 0, zRotation);
		transform.rotation = rot;

		pos = transform.position;
		vel = new Vector3 (0, Input.GetAxis ("Vertical") * speed * Time.deltaTime, 0);
		pos += rot * vel;
		checkBounds ();



		transform.position = pos;*/

		var move = new Vector3 ();

		if (Input.GetKey (KeyCode.A)) {
			move += Vector3.left;
		}
		if (Input.GetKey (KeyCode.D)) {
			move += Vector3.right;
		}
		if (Input.GetKey (KeyCode.W)) {
			move += Vector3.up;
		} 
		if (Input.GetKey (KeyCode.S)) {
			move += Vector3.down;
		}
			
		transform.position += move * speed * Time.deltaTime;
		pos = transform.position;

		checkBounds ();

		transform.position = pos;
	
	}
	//Check if player is out of bounds
	void checkBounds(){
		//check top and bottome bounds
		if (pos.y+playerSize > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - playerSize;
		}
		if (pos.y-playerSize < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + playerSize;
		}
		//check left and right bounds
		float screen = (float)Screen.width / (float)Screen.height;
		float orthoWidth = Camera.main.orthographicSize * screen;
		if (pos.x+playerSize > orthoWidth) {
			pos.x = orthoWidth - playerSize;
		}
		if (pos.x-playerSize < -orthoWidth) {
			pos.x = -orthoWidth + playerSize;
		}
	
	}
}
