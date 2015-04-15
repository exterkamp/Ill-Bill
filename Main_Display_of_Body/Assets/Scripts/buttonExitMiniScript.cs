using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class buttonExitMiniScript : MonoBehaviour {

	public void onClickExitToMain(){
		if (BodyMapController.instance != null) {
			GameObject.Destroy(BodyMapController.instance.gameObject);
			BodyMapController.instance = null;
			DictionaryGameState.instance.setmarkers(new List<string[]>());
		}
		Application.LoadLevel ("MainMenu");
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (BodyMapController.instance != null) {
				GameObject.Destroy (BodyMapController.instance.gameObject);
				BodyMapController.instance = null;
				DictionaryGameState.instance.setmarkers (new List<string[]> ());
			}
			Application.LoadLevel ("MainMenu");
		}
	}
}
