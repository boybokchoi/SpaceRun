using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	public float timer = 2f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, timer);
	}
}
