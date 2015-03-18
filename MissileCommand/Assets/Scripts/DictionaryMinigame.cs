using UnityEngine;
using System.Collections;

public class DictionaryMinigame : MonoBehaviour {

	private int difficulty;

	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad (this.gameObject);
		difficulty = 1;
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


}
