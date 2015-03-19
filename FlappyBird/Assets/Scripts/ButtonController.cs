using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
	public GameObject minigameDictionary;
	Text scoreText;
	Text winText;
	DictionaryMinigame DM;
	
	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectsWithTag("dictionary_minigame").Length == 0)
			Instantiate(minigameDictionary);
		
		GameObject g = GameObject.FindGameObjectWithTag ("dictionary_minigame");
		DM = g.GetComponent<DictionaryMinigame> ();
		scoreText = (Text)Camera.main.transform.FindChild("Canvas").transform.FindChild("Score").gameObject.GetComponent<Text>();
		winText = (Text)Camera.main.transform.FindChild("Canvas").transform.FindChild("Win").gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + DM.getScore ().ToString();
		winText.text = "Win: " + DM.getWL ().ToString();
	}
	
	public void onClickHandler(){
		DM.setDiff ((int)Camera.main.transform.FindChild ("Canvas").transform.FindChild("Slider").GetComponent<Slider> ().value);
		print (DM.getDiff());
		DM.setScore(0);
		DM.setWL(false);
		Application.LoadLevel ("FlappyBirdMain");
	}
}
