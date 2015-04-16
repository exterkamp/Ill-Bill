using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePromptScript : MonoBehaviour {
	public static GamePromptScript instance;
	public bool guiShow = false;
	public GameObject UI;
	public GameObject button;
	public GameObject Panel;
	//private string menu;

	public Text scoreText;
	public Text resultText;

	private static int prevwins;
	private static int prevscore;
	private static int score;
	private static int wins;

	// Use this for initialization
	void Start () {
		//guiShow = true;

		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else if(instance != this){
			Destroy (this.gameObject);
		}


		if (instance != null) {
			//wins = DictionaryMinigame.instance.getWins ();
			//losses = DictionaryMinigame.instance.getLosses ();



			if((wins = BodyMapController.instance.wins) !=0 || BodyMapController.instance.losses != 0){
				guiShow = true;
				if(prevwins<BodyMapController.instance.wins){
				resultText.text = "You won !!!";
				}else{
				resultText.text = "You lost :(";
				}
				score=BodyMapController.instance.score;
				scoreText.text = "You got a score of "+(score-prevscore);
			}else{
				guiShow = false;
			}

			prevwins = wins;
			prevscore= score;
		}//inst!=null




	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	void Awake(){
		guiShow = true;
		Debug.Log ("Access");

		if (instance != null) {
			wins = DictionaryMinigame.instance.getWins ();
			losses = DictionaryMinigame.instance.getLosses ();
			Debug.Log ("Access1");
			if(losses !=0 && wins != 0){
				
				guiShow = true;}else{guiShow = true;}
			
		}//inst!=null

	}
*/
	public void noGUI(){
		guiShow = false;
	}
	
	public void showGUI(string scene, string injuryText, string minigameText, int difficultyText){
		guiShow = true;
		//menu = scene;
		/*injury.GetComponent<Text> ().text = injuryText;
		minigame.GetComponent<Text> ().text = minigameText;
		Difficulty.GetComponent<Text> ().text = "Difficulty: " + difficultyText;*/
	}
	
	void OnGUI(){
		if (guiShow) {
			//GUI.DrawTexture(new Rect(Screen.width-Screen.width/3,0,Screen.width/3,Screen.height/3),speechBubble);
			UI.SetActive (true);
		} else {
			UI.SetActive(false);
		}
		
	}
	
}
