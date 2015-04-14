using UnityEngine;
using System.Collections;

public class buttonExitMiniScript : MonoBehaviour {

	public void onClickExitToMain(){
		Application.LoadLevel ("MainMenu");
	}
}
