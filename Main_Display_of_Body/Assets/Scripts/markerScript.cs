using UnityEngine;

using System.Collections;

public class markerScript : MonoBehaviour {

	public bool highlighted = false;
	public int difficulty;
	public string minigame;
	public GameObject bodyPoint;


	public markerScript(int diff, string game, GameObject point){
		this.difficulty = diff;
		this.minigame = game;
		this.bodyPoint = point;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !highlighted) {
			transform.localScale  = new Vector3(1F, 1F, 1F);
		}



	}

	/*void OnMouseEnter() {
		highlighted = true;
	}*/

	void OnMouseDown() {
		//check if hit for a second time, if it is launch minigame!
		if (highlighted) {
			DictionaryMinigame.instance.setDiff(difficulty);
			Application.LoadLevel (minigame);
		}

		highlighted = true;
		transform.localScale  = new Vector3(1.25F, 1.25F, 1.25F);
	}

	void OnMouseExit(){
		highlighted = false;
	}

}
