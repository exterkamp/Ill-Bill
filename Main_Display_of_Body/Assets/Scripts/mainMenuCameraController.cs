using UnityEngine;
using System.Collections;

public class mainMenuCameraController : MonoBehaviour {

	public void clickListenerPlay(){
		//Debug.Log ("Play");
		Application.LoadLevel ("BodyMap");
	}

	public void clickListenerOptions(){
		Debug.Log ("Options");
	}

	public void clickListenerExit(){
		Debug.Log ("Exit");
	}

}
