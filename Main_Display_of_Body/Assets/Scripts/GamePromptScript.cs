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
	private static int prevlosses;
	private static int prevscore;
	private static int score;
	private static int wins;
	private static int losses;
	
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
			
			
			if(((wins = BodyMapController.instance.wins) !=0 || (losses = BodyMapController.instance.losses) != 0)   ){
				
				if(wins != prevwins|| losses != prevlosses){
					guiShow = true;
					
					if(prevwins<BodyMapController.instance.wins){
						resultText.text = "You won !!!";
					}else{
						resultText.text = "You lost :(";
					}
					
					score=BodyMapController.instance.score;
					scoreText.text = "You got a score of "+(score-prevscore);
					
					
					prevwins = wins;
					prevlosses = losses;
					prevscore= score;
					
				}else{
					guiShow = false;
				}
				
			}else{
				guiShow = false;
				prevwins = 0;
				prevlosses = 0;
				prevscore = 0;
			}
			
			
		}//inst!=null
		
		
		
		
	}

	public void noGUI(){
		guiShow = false;
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
