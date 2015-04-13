using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class ButtonController : MonoBehaviour {

	public GameObject dictionary;
	public int goal;
	Text scoreText;
	Text goalText;
	Text winText;
	Text diffText;
	Text highScoreText;
	private int highScore = 0;

	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectsWithTag("dictionary_minigame").Length == 0)
			Instantiate(dictionary);

		scoreText = (Text)Camera.main.transform.FindChild("Canvas").transform.FindChild("Score").gameObject.GetComponent<Text> ();
		goalText = (Text)Camera.main.transform.FindChild ("Canvas").transform.FindChild ("Goal").gameObject.GetComponent<Text> ();
		winText = (Text)Camera.main.transform.FindChild("Canvas").transform.FindChild("Win").gameObject.GetComponent<Text> ();
		diffText = (Text)Camera.main.transform.FindChild ("Canvas").transform.FindChild ("Difficulty").gameObject.GetComponent<Text> ();
		highScoreText = (Text)Camera.main.transform.FindChild ("Canvas").transform.FindChild ("High Score").gameObject.GetComponent<Text> ();
		highScore = int.Parse (readStringFromFile ("highscore"));
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + DictionaryMinigame.instance.getScore ().ToString();
		goalText.text = "Goal: " + DictionaryMinigame.instance.getGoal ().ToString ();
		winText.text = "Win: " + DictionaryMinigame.instance.getWL ().ToString();
		if (DictionaryMinigame.instance.getScore () >= highScore) {
			highScore = DictionaryMinigame.instance.getScore ();
			writeStringToFile (highScore.ToString (), "highscore");
		} else {
			highScore = int.Parse (readStringFromFile ("highscore"));
		}
		highScoreText.text = "High Score: " + highScore.ToString ();
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

	public string pathForDocumentsFile( string filename ){ 
		if (Application.platform == RuntimePlatform.Android) {
			string path = Application.persistentDataPath;	
			path = path.Substring(0, path.LastIndexOf( '/' ) );	
			return Path.Combine (path, filename);
		}	
		else {
			string path = Application.dataPath;	
			path = path.Substring(0, path.LastIndexOf( '/' ) );
			return Path.Combine (path, filename);
		}
	}

	public void writeStringToFile(string str, string filename){
		#if !WEB_BUILD
		string path = pathForDocumentsFile(filename);
		FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
		
		StreamWriter sw = new StreamWriter( file );
		sw.WriteLine( str );
		
		sw.Close();
		file.Close();
		#endif	
	}

	public string readStringFromFile(string filename) {
		#if !WEB_BUILD
		string path = pathForDocumentsFile( filename );
		
		if (File.Exists(path)) {
			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader( file );
			
			string str = null;
			str = sr.ReadLine ();
			
			sr.Close();
			file.Close();
			
			return str;
		} else {
			return "0";
		}
		#else
		return null;
		#endif 
	}
}
