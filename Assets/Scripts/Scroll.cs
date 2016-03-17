using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float speed = 0.2f;
	private float count = 0f;
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;

		if (count >= 15) {
			count = 0f;
			speed += .1f;
		}

		Vector2 offset = new Vector2 (0, Time.time * speed);

		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
