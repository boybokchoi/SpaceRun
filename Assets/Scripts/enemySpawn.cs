using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {

	public GameObject enemy;
	public GameObject rock1;
	public GameObject rock2;
	float enemyRate = 5f;
	float nextEnemy = 1;
	float distance = 20f;
	float distRock = 15f;
	float counter = 0f;
	float rockCounter = 15f;
	float rockCounter2 = 25f;


	void Update () {
		counter += Time.deltaTime;
		rockCounter -= Time.deltaTime;
		rockCounter2 -= Time.deltaTime;
		nextEnemy -= Time.deltaTime;

		if (nextEnemy <= 0) {
			nextEnemy = enemyRate;
			enemyRate *= 0.9f;
			if (enemyRate < 3)
				enemyRate = 3;
			
			Vector3 offset = Random.onUnitSphere;
			Vector3 offset1 = Random.onUnitSphere;
			Vector3 offset2 = Random.onUnitSphere;

			offset.z = 0;
			offset1.z = 0;
			offset2.z = 0;

			offset = offset.normalized * distance;
			offset1 = offset1.normalized * distRock;
			offset2 = offset2.normalized * distRock;

			Instantiate (enemy,transform.position + offset, Quaternion.identity);

			if (rockCounter <= 0) {
				Instantiate (rock1, transform.position + offset1, Quaternion.identity);
				rockCounter = 15f;
			}

			if (rockCounter2 <= 0) {
				Instantiate (rock2, transform.position + (offset2 * 2), Quaternion.identity);
				rockCounter2 = 25f;
			}
		}
	}

}
