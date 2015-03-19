using UnityEngine;
using System.Collections;

public class DictionaryMinigame : MonoBehaviour {
	
	private int difficulty;
	private int score;
	private bool winLose;  //true for win and false for lose
	
	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad (this.gameObject);
		difficulty = 1;
		score = 0;
		winLose = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void setDiff(int newDiff){
		difficulty = newDiff;
	}
	
	public int getDiff(){
		return difficulty;
	}
	
	public void setScore(int newScore){
		score = newScore;
	}
	
	public int getScore(){
		return score;
	}

	public void setWL(bool newWL){
		winLose = newWL;
	}
	
	public bool getWL(){
		return winLose;
	}

}

