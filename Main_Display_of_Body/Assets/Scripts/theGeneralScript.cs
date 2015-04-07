using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class theGeneralScript : MonoBehaviour {
	
	public bool guiShow = false;
	public GameObject UI;
	public GameObject button;
	private string menu;
	public GameObject injury;
	public GameObject minigame;
	public GameObject Difficulty;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void noGUI(){
		guiShow = false;
	}
	
	public void showGUI(string scene, string injuryText, string minigameText, int difficultyText){
		guiShow = true;
		menu = scene;
		injury.GetComponent<Text> ().text = injuryText;
		minigame.GetComponent<Text> ().text = minigameText;
		Difficulty.GetComponent<Text> ().text = "Difficulty: " + difficultyText;
	}
	
	void OnGUI(){
		if (guiShow) {
			//GUI.DrawTexture(new Rect(Screen.width-Screen.width/3,0,Screen.width/3,Screen.height/3),speechBubble);
			UI.SetActive (true);
		} else {
			UI.SetActive(false);
		}
		
	}
	
	public void playGame(){
		Application.LoadLevel (menu);
	}
	
}
