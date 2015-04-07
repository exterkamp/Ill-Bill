using UnityEngine;
using System.Collections;

public class BodyMapController : MonoBehaviour {
	public static BodyMapController instance;
	public mapGraphController mapControl;
	public int wins;
	public int losses;
	public int score;

	void Start(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else if(instance != this){
			Destroy (this.gameObject);
		}

		//seed first points
		int max = Random.Range (1, 3);
		for (int i = 0; i <= max; i++) {
			mapControl.generate ();
		}
	}

	// Use this for initialization
	void Awake () {

		if (instance != null) {
			if (DictionaryMinigame.instance.getWL ()) {
				instance.wins++;
				//delete the last marker clicked
			} else {
				instance.losses++;
				//increase diff of last markerScript clicked
			}
			mapControl.generate();
			instance.score += DictionaryMinigame.instance.getScore ();
		}
	}
	
	void OnGUI(){
		GUI.Label (new Rect (10, 10, 100, 30), "Wins: " + wins);
		GUI.Label (new Rect (10, 40, 150, 30), "Losses: " + losses);
		GUI.Label (new Rect (10, 70, 150, 30), "Score: " + score);
	}
}
