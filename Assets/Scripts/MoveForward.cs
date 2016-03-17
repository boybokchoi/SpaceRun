using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	Vector3 vel,pos;
	public float maxSpeed = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		pos = transform.position;
		vel = new Vector3 (0,maxSpeed * Time.deltaTime, 0);
		pos += transform.rotation * vel;
		transform.position = pos;
	}
}
