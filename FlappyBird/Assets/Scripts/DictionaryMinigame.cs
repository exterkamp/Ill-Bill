using UnityEngine;
using System.Collections;

public class DictionaryMinigame : MonoBehaviour {
	
	private int difficulty;
	private int score;
	private bool winLose;  //true for win and false for lose
	public Environ environ;

	public enum Environ
	{
		Vein,
		Bone,
		Cut
	}

	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad (this.gameObject);
		difficulty = 1;
		score = 0;
		winLose = false;
		environ = Environ.Vein;
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

	public void setEnviron(int env){
		environ = (Environ)env;
	}

	public int getEnviron(){
		return (int)environ;
	}


}

