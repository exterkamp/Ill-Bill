using UnityEngine;
using System.Collections;

public class markerScript : MonoBehaviour {

	public bool highlighted = false;

	public string minigame;


	// Use this for initialization
	void Start () {
	
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
			Application.LoadLevel (minigame);
		}

		highlighted = true;
		transform.localScale  = new Vector3(1.25F, 1.25F, 1.25F);
	}

	void OnMouseExit(){
		highlighted = false;
	}

}
