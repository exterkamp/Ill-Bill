using UnityEngine;
using System.Collections;

public class MinigameSelect : MonoBehaviour {

	string minigame1 = "Menu";
	string minigame2 = "SplashMenu";

	void onStart(){
		Screen.orientation = ScreenOrientation.Portrait;
	}

	public void handleArtery(){
		Application.LoadLevel(minigame1);
	}

	public void handleVirus(){
		Application.LoadLevel(minigame2);
	}


	/*void OnGUI () {

		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height - 50, 100, 40), "Artery Run")) {
			Application.LoadLevel(minigame1);
		}

		if (GUI.Button (new Rect (Screen.width / 2 + 50, Screen.height - 50, 100, 40), "Virus Defense")) {
			Application.LoadLevel(minigame2);
		}
	}*/
	
}