using UnityEngine;
using System.Collections;

public class PlayerBeam : MonoBehaviour {

	public GameObject bulletPrefab;
	int beamLayer;

	Vector3 offset;
	float delay = .25f;
	float cdTimer = 0;
	void Start(){
		beamLayer = gameObject.layer;
	}
	void Update () {

		cdTimer -= Time.deltaTime;
		/*if (Input.GetButton ("Fire1") && cdTimer <= 0) {
			cdTimer = delay;

			offset = transform.rotation * new Vector3(0, 0.5f, 0);

			//set the bullet to the same layer as the current gameobject
			GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, transform.position + offset, transform.rotation);
			bulletGO.layer = beamLayer;
		}*/

		Debug.Log ("beamLayer" + beamLayer);

		if (Input.GetMouseButton(0) && cdTimer <= 0) {

			cdTimer = delay;

			offset = transform.rotation * new Vector3(0, 0.5f, 0);

			//set the bullet to the same layer as the current gameobject
			GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, transform.position + offset, transform.rotation);
			bulletGO.layer = beamLayer;
		}
	}
}
