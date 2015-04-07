using UnityEngine;

using System.Collections;

public class markerScript : MonoBehaviour {

	private Camera cam;
	
	public string minigame;
	public string injury;
	public string minigameText;
	public int difficulty;
	public GameObject bodyPoint;


	void Start(){
		cam = Camera.main;
	}

	public markerScript(int diff, string game, GameObject point){

		this.difficulty = diff;
		this.minigame = game;
		this.bodyPoint = point;
	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnMouseDown() {
		GameObject.FindGameObjectWithTag("theGeneral").GetComponent<theGeneralScript>().showGUI(minigame,injury,minigameText,difficulty);
		cam.GetComponent<cameraLerper> ().moveTo (transform.position, 0.5f);
	}

}
