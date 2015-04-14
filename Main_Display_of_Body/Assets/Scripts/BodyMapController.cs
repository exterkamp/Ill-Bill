using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class BodyMapController : MonoBehaviour {
	public static BodyMapController instance;
	public mapGraphController mapControl;
	public int wins;
	public int losses;
	public int score;
	private string fileName = "GameData";

	void Start(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
			//seed first points
			//print ("seeding");
			if (File.Exists (pathForDocumentsFile(fileName))) {
				//Debug.Log ("reading data");
				readData(fileName);
			} else {
				//Debug.Log("seeding");
				int max = Random.Range (1, 3);
				for (int i = 0; i <= max; i++) {
					mapControl.generate ();
					writeData (fileName);
				}
			}
			mapControl.renderExisting ();
		} else if(instance != this){
			Destroy (this.gameObject);
		}
		//mapControl.renderExisting ();

	}

	// Use this for initialization
	void Awake () {

		if (instance != null) {
			if (DictionaryMinigame.instance.getWL ()) {
				instance.wins++;
				//delete the last marker clicked
				DictionaryGameState.instance.deleteCurrent();

			} else {
				instance.losses++;
				string[] s = DictionaryGameState.instance.getCurrent();
				int diff = System.Convert.ToInt32(s[3]);
				if (diff != 10){
					diff += 1;
					s[3] = diff.ToString();
				}
				else{
					//spread disease
				}


				//increase diff of last markerScript clicked
			}
			//if (DictionaryGameState.instance.getMarkers() != null){
			//print ("making more and rendering");
			//mapControl.renderExisting ();
			//Debug.Log("generating more");
			mapControl.generate();
			mapControl.renderExisting();
			//}
			instance.score += DictionaryMinigame.instance.getScore ();
			writeData (fileName);
		}
	}
	/*
	void OnGUI(){
		GUI.Label (new Rect (10, 10, 100, 30), "Wins: " + wins);
		GUI.Label (new Rect (10, 40, 150, 30), "Losses: " + losses);
		GUI.Label (new Rect (10, 70, 150, 30), "Score: " + score);
	}*/

	public string pathForDocumentsFile(string filename) { 
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
	
	public void writeData(string filename) {
		#if !WEB_BUILD
		string path = pathForDocumentsFile(filename);
		FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
		
		StreamWriter sw = new StreamWriter(file);
		sw.WriteLine (instance.wins.ToString ());
		//print ("write wins: " + instance.wins.ToString ());
		sw.WriteLine (instance.losses.ToString ());
		//print ("write losses: " + instance.losses.ToString ());
		sw.WriteLine (instance.score.ToString ());
		//print ("write score: " + instance.score.ToString ());
		List<string[]> markerWrite = DictionaryGameState.instance.getMarkers ();
		for (int i = 0; i < markerWrite.Count; i++) {
			string[] strArr = markerWrite[i];
			sw.WriteLine(strArr[0] + ";" + strArr[1] + ";" + strArr[2] + ";" + strArr[3] + ";" + strArr[4] + ";" + strArr[5] + ";" + strArr[6] + ";" + strArr[7]);
		}
		sw.Close();
		file.Close();
		#endif	
	}
	
	public void readData(string filename) {
		#if !WEB_BUILD
		string path = pathForDocumentsFile(filename);
		
		if (File.Exists(path)) {
			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader(file);
			
			string str = null;
			str = sr.ReadLine ();
			//print ("read wins: " + str);
			instance.wins = int.Parse (str);
			str = sr.ReadLine ();
			//print ("read losses: " + str);
			instance.losses = int.Parse (str);
			str = sr.ReadLine ();
			//print ("read score: " + str);
			instance.score = int.Parse (str);
			while ((str = sr.ReadLine ()) != null) {
				//print ("read generate: " + str);
				mapControl.generate (str);
			}
			
			sr.Close();
			file.Close();
		}
		#else
		#endif 
	}
}
