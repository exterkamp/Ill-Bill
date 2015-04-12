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
			//seed first points
			//print ("seeding");
			int max = Random.Range (1, 3);
			for (int i = 0; i <= max; i++) {
				mapControl.generate ();
			}
			mapControl.renderExisting ();
		} else if(instance != this){
			Destroy (this.gameObject);
		}
		//mapControl.renderExisting ();

	
	}

	// Use this for initialization
	void Awake () {

		if (instance != null) {
			if (DictionaryMinigame.instance.getWL ()) {
				instance.wins++;
				//delete the last marker clicked
				DictionaryGameState.instance.deleteCurrent();

			} else {
				instance.losses++;
				string[] s = DictionaryGameState.instance.getCurrent();
				int diff = System.Convert.ToInt32(s[3]);
				if (diff != 10){
					diff += 1;
					s[3] = diff.ToString();
				}
				else{
					//spread disease
				}


				//increase diff of last markerScript clicked
			}
			//if (DictionaryGameState.instance.getMarkers() != null){
			//print ("making more and rendering");
			//mapControl.renderExisting ();
			mapControl.generate();
			mapControl.renderExisting();
			//}
			instance.score += DictionaryMinigame.instance.getScore ();
		}
	}
	/*
	void OnGUI(){
		GUI.Label (new Rect (10, 10, 100, 30), "Wins: " + wins);
		GUI.Label (new Rect (10, 40, 150, 30), "Losses: " + losses);
		GUI.Label (new Rect (10, 70, 150, 30), "Score: " + score);
	}*/
}
