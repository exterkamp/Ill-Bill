using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectsWithTag("dictionary_minigame").Length == 0)
			Instantiate(Resources.Load("MinigameInfoDictionary"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickHandler(){
		//get dictionary
		GameObject g = GameObject.FindGameObjectWithTag ("dictionary_minigame");
		DictionaryMinigame DM = g.GetComponent<DictionaryMinigame> ();
		DM.setDiff ((int)Camera.main.transform.FindChild ("Canvas").transform.FindChild("Slider").GetComponent<Slider> ().value);
		print (DM.getDiff());
		Application.LoadLevel ("missileCommandMain");
	}
}
