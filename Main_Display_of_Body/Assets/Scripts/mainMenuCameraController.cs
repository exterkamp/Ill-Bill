using UnityEngine;
using System.Collections;
using System.IO;

public class mainMenuCameraController : MonoBehaviour {
	private string fileName = "GameData";

	public void clickListenerPlay(){
		//Debug.Log ("Play");
		Application.LoadLevel ("BodyMap");
	}

	public void clickListenerNewPlay(){
		//Debug.Log ("Delete the old GameData and make a new play");
		deleteData ();
		Application.LoadLevel ("BodyMap");
	}

	public void clickListenerExit(){
		//Debug.Log ("Exit");
		Application.Quit();
	}

	private string pathForDocumentsFile(string filename) { 
		if (Application.platform == RuntimePlatform.Android) {
			string path = Application.persistentDataPath;	
			path = path.Substring(0, path.LastIndexOf( '/' ));	
			return Path.Combine (path, filename);
		}	   
		else {
			string path = Application.dataPath;	
			path = path.Substring(0, path.LastIndexOf( '/' ));
			return Path.Combine (path, filename);
		}
	}

	private void deleteData() {
		if (File.Exists (pathForDocumentsFile(fileName))) {
			File.Delete (pathForDocumentsFile (fileName));
		}
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit ();
	}
}
