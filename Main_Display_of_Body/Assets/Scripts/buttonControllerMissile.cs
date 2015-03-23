using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonControllerMissile : MonoBehaviour {
	
	Text scoreText;
	Text winText;
	Text difficulty;
	
	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectsWithTag("dictionary_minigame").Length == 0)
			Instantiate(Resources.Load("MinigameInfoDictionary"));
		
		//GameObject g = GameObject.FindGameObjectWithTag ("dictionary_minigame");
		//DM = g.GetComponent<DictionaryMinigame> ();
		scoreText = (Text)Camera.main.transform.FindChild("Canvas").transform.FindChild("Score").gameObject.GetComponent<Text>();
		winText = (Text)Camera.main.transform.FindChild("Canvas").transform.FindChild("Win").gameObject.GetComponent<Text>();
		difficulty = (Text)Camera.main.transform.FindChild("Canvas").transform.FindChild("Difficulty").gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + DictionaryMinigame.instance.getScore ().ToString();
		winText.text = "Win: " + DictionaryMinigame.instance.getWL ().ToString();
	}
	
	public void onChanged(){
		DictionaryMinigame.instance.setDiff ((int)Camera.main.transform.FindChild ("Canvas").transform.FindChild("Slider").GetComponent<Slider> ().value);
		difficulty.text = DictionaryMinigame.instance.getDiff ().ToString();
	}
	
	public void onClickHandler(){
		DictionaryMinigame.instance.setDiff ((int)Camera.main.transform.FindChild ("Canvas").transform.FindChild("Slider").GetComponent<Slider> ().value);
		print (DictionaryMinigame.instance.getDiff());
		Application.LoadLevel ("missileCommandMain");
	}
}
