using UnityEngine;
using System.Collections;

public class EnemyBeam : MonoBehaviour {

	Transform player;
	public GameObject bulletPrefab;
	int beamLayer;
	Vector3 offset;
	float delay = .50f;
	float cdTimer = 0;
	void Start(){
		beamLayer = gameObject.layer;
	}
	void Update () {

		if (player == null) {
			//Locate player object
			GameObject go = GameObject.FindWithTag("Player");

			if (go != null) {
				player = go.transform;
			}
		}


		cdTimer -= Time.deltaTime;
		if (cdTimer <= 0 && player!=null && Vector3.Distance(transform.position, player.position) < 15 ){
			cdTimer = delay;

			offset = transform.rotation * new Vector3(0, 0.5f, 0);
			GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, transform.position + offset, transform.rotation);
			bulletGO.layer = beamLayer;
		}
	}
}
