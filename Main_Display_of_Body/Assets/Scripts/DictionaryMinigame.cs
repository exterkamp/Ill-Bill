using UnityEngine;
using System.Collections;

public class DictionaryMinigame : MonoBehaviour {
	public static DictionaryMinigame instance;
	private int difficulty;
	private int goal;
	private int score;
	private bool winLose;  //true for win and false for lose
	
	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else if(instance != this){
			Destroy (gameObject);
		}
		instance.difficulty = 1;
		instance.score = 0;
		instance.winLose = false;
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

	public void incScore(int incAmount) {
		score += incAmount;
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

