using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public int highscore = 0;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("Score") != 0)
			highscore = PlayerPrefs.GetInt ("Score");
	}

	void OnGUI(){
		GUIStyle style = new GUIStyle(); 
		style.fontSize = 50;

		GUI.contentColor = Color.cyan;
		 
		GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 130, 50, 20), "   " + highscore, style);

		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 50), "Quit.")) {
				SceneManager.LoadScene ("menu");
		}
	}
}
