using UnityEngine;

using System.Collections;

public class markerScript : MonoBehaviour {

	private Camera cam;
	
	public string minigame;
	public string injury;
	public string minigameText;
	public int difficulty;
	public GameObject bodyPoint;
	public int bPindex;
	public int ID;
	public Sprite[] markerSprites;

	void Start(){
		cam = Camera.main;
		gameObject.GetComponent<SpriteRenderer> ().sprite = markerSprites[difficulty - 1];
	}

	public markerScript(int diff, string game, GameObject point, int ID){

		this.difficulty = diff;
		this.minigame = game;
		this.bodyPoint = point;
		this.ID = ID;

		//gameObject.GetComponent<SpriteRenderer> ().sprite = markerSprites[diff - 1];

	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnMouseDown() {
		DictionaryGameState.instance.setCurrentMarker (ID);
		string[] cur = DictionaryGameState.instance.getCurrent ();
		int diff = System.Convert.ToInt32(cur[3]);
		DictionaryMinigame.instance.setDiff (diff);
		GameObject.FindGameObjectWithTag("theGeneral").GetComponent<theGeneralScript>().showGUI(minigame,injury,minigameText,difficulty);
		cam.GetComponent<cameraLerper> ().moveTo (transform.position, 0.5f);
	}

}
