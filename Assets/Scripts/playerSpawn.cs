using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerSpawn : MonoBehaviour {

	float score = 0;
	public GameObject playerPrefab, heartPrefab;
	float timer;
	public int lives = 4;
	bool gameOver;
	GameObject playerInstance;
	GameObject pill1, pill2, pill3;

	// Use this for initialization
	void Start () {
		gameOver = false;
		pillSpawner();
		spawner();
	}

	void pillSpawner(){
		Vector3 pos1 = new Vector3 (8, 9.5f, 0);
		Vector3 pos2 = new Vector3 (8.5f, 9.5f, 0);
		Vector3 pos3 = new Vector3 (9, 9.5f, 0);
		pill1 = (GameObject)Instantiate(heartPrefab,pos1,Quaternion.identity);
		pill2 = (GameObject)Instantiate(heartPrefab,pos2,Quaternion.identity);
		pill3 = (GameObject)Instantiate(heartPrefab,pos3,Quaternion.identity);
	}

	void spawner(){
		timer = 3f;		 //time between death and respawn
		lives--;

		if (lives == 2) {
			Destroy (pill3);
		}
		if (lives == 1) {
			Destroy (pill2); 
		}
		if (lives == 0) {
			Destroy (pill1);
		}

		playerInstance = (GameObject)Instantiate(playerPrefab,transform.position,Quaternion.identity);
		Debug.Log (playerInstance.layer);
	}
	// Update is called once per frame
	void Update () {

		if (playerInstance == null && lives > 0) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				spawner ();
			}
		}
		if (playerInstance == null && lives == 0) {
			gameOver = true;
		}

		if(!gameOver)
			score += Time.deltaTime;

		//Debug.Log (score);
	}
	void OnGUI(){
		GUIStyle style = new GUIStyle(); 
		style.fontSize = 20;

		GUI.contentColor = Color.cyan;

		if(lives > 0 || playerInstance != null){
			GUI.Label (new Rect (0, 0, 400, 400), "Score: " + (int)score);
		}else{
			GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "  Game Over!\n  Your Score: " + (int)score);
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 50), "PLAY AGAIN!"))
				SceneManager.LoadScene ("Prototype");
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 50), "Quit.")) {
				saveScore ();
				Application.Quit ();
			}
		}
	}

	void saveScore()
	{
		if (PlayerPrefs.GetInt ("Score") != 0) {

			if (PlayerPrefs.GetInt ("Score") < score) {
				PlayerPrefs.SetInt ("Score", (int)score);
			}
		} else {
			PlayerPrefs.SetInt ("Score", (int)score);
		}

		PlayerPrefs.Save ();
	}
}
