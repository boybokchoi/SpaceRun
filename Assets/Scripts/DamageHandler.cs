using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {

	public int HP = 1;

	public float invulnPeriod = 0;
	float invulTimer = 0;
	float counter = 0;
	int defLayer;

	public GameObject explosionPrefab;
	SpriteRenderer sr;

	void Start(){
		defLayer = gameObject.layer;
		sr = GetComponent<SpriteRenderer> ();
		if (sr == null)
			sr = transform.GetComponentInChildren <SpriteRenderer> ();
	}

	void OnTriggerEnter2D() {
		HP--;
		if (invulnPeriod > 0) {
			invulTimer = invulnPeriod;
			gameObject.layer = 10;
		}
	}

	void Update() {
		counter += Time.deltaTime;

		if (counter >= 30) {
			counter = 0f;

			if (gameObject.layer == 8) {
				HP += 2;
			}
			if (gameObject.layer == 9) {
				HP += 1;
			}
		}

		if (invulTimer > 0) {
			invulTimer -= Time.deltaTime;
			if (invulTimer <= 0) {
				gameObject.layer = defLayer;
				sr.enabled = true;
			} else {
				sr.enabled = !sr.enabled;
			}
		}
		if (HP <= 0)
			Die ();
	}

	void Die() {
		Debug.Log ("Die called");
		Instantiate (explosionPrefab, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}