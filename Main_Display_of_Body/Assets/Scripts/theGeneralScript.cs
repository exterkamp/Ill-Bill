using UnityEngine;
using System.Collections;

public class theGeneralScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void displayGUI(string scene, string injury, string minigame, int difficulty){
		//spawn a GUI element
		print ("Output: " + scene + ", " + injury + ", " + minigame + ", " + difficulty);

	}
}
