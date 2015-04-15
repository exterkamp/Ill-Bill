using UnityEngine;
using System.Collections;

public class mainMenuCameraController : MonoBehaviour {

	public void clickListenerPlay(){
		//Debug.Log ("Play");
		Application.LoadLevel ("BodyMap");
	}

	public void clickListenerNewPlay(){
		Debug.Log ("Delete the old GameData and make a new play");

		Application.LoadLevel ("BodyMap");
	}

	public void clickListenerExit(){
		//Debug.Log ("Exit");
		Application.Quit();
	}

}
