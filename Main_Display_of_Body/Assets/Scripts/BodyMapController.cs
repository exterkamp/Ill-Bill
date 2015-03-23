using UnityEngine;
using System.Collections;

public class BodyMapController : MonoBehaviour {
	public static BodyMapController instance;
	public int wins;
	public int losses;
	public int score;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else if(instance != this){
			Destroy (gameObject);
		}

		if (DictionaryMinigame.instance.getWL ()) {
			instance.wins++;
		} 
		else {
			instance.losses++;
		}
		instance.score += DictionaryMinigame.instance.getScore ();
	}
	
	void OnGUI(){
		GUI.Label (new Rect (10, 10, 100, 30), "Wins: " + wins);
		GUI.Label (new Rect (10, 40, 150, 30), "Losses: " + losses);
		GUI.Label (new Rect (10, 70, 150, 30), "Score: " + score);
	}
}
