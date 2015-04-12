using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

	public GameObject dictionary;
	public int goal;
	Text scoreText;
	Text goalText;
	Text winText;
	Text diffText;

	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectsWithTag("dictionary_minigame").Length == 0)
			Instantiate(dictionary);

		scoreText = (Text)Camera.main.transform.FindChild("Canvas").transform.FindChild("Score").gameObject.GetComponent<Text> ();
		goalText = (Text)Camera.main.transform.FindChild ("Canvas").transform.FindChild ("Goal").gameObject.GetComponent<Text> ();
		winText = (Text)Camera.main.transform.FindChild("Canvas").transform.FindChild("Win").gameObject.GetComponent<Text> ();
		diffText = (Text)Camera.main.transform.FindChild ("Canvas").transform.FindChild ("Difficulty").gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + DictionaryMinigame.instance.getScore ().ToString();
		goalText.text = "Goal: " + DictionaryMinigame.instance.getGoal ().ToString ();
		winText.text = "Win: " + DictionaryMinigame.instance.getWL ().ToString();
	}

	public void onChanged(){
		DictionaryMinigame.instance.setDiff ((int)Camera.main.transform.FindChild ("Canvas").transform.FindChild("Slider").GetComponent<Slider> ().value);
		diffText.text = DictionaryMinigame.instance.getDiff ().ToString();
	}
	
	public void onClickHandler(){
		DictionaryMinigame.instance.setDiff ((int)Camera.main.transform.FindChild ("Canvas").transform.FindChild("Slider").GetComponent<Slider> ().value);
		DictionaryMinigame.instance.setScore (0);
		DictionaryMinigame.instance.setGoal (goal);
		Application.LoadLevel ("BulletHellMain");
	}
}
