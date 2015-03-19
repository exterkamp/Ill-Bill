using UnityEngine;
using System.Collections;

public class FlappyDictionary : MonoBehaviour {
	

	private int attempts=3;
	
	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad (this.gameObject);
		attempts=3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void setAttempts(int newA){
		attempts= newA;
	}

	public void decAttempts(){
		attempts--;
	}
	
	public int getAttempts(){
		return attempts;
	}
	

	
}

