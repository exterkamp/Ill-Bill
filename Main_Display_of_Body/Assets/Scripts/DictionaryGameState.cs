using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DictionaryGameState : MonoBehaviour {
	public static DictionaryGameState instance;
	private List<string[]> markers;//0 = Vector3, 1 = injuryText, 2 = minigameText, 3 = diff, 4 = sceneName, 5 = bP,6 = bPindex, 7 = ID
	private int currentMarker;
	private int nextID;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else if(instance != this){
			Destroy (gameObject);
		}
		markers = new List<string[]>();
		nextID = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public List<string[]> getMarkers(){
		return markers;
	}

	/*public List<GameObject> getMarkerObjects(){
		print ("getting objects");
		List<GameObject> markerOBJ = new List<GameObject> ();
		for (int i = 0; i < markers.Count; i++) {
			string[] content = markers[i];
			GameObject marker = null;
			transform.position.ToString ();

			marker = (GameObject)Instantiate (Resources.Load ("Marker"),Vector3FromString(content[0]), Quaternion.identity);
			marker.SetActive(false);
			markerScript ms = marker.GetComponent<markerScript> ();
			ms.injury = content[1];
			ms.minigameText = content[2];
			ms.difficulty = System.Convert.ToInt32(content[3]);
			ms.minigame = content[4];
			ms.bodyPoint = null;
			ms.bPindex = System.Convert.ToInt32(content[6]);
			markerOBJ.Add(marker);
		}
		return markerOBJ;
	}

	public Vector3 Vector3FromString(string Vector3string) {

		//get first number (x)
		int startChar = 1;
		int endChar = Vector3string.IndexOf(",");
		int lastEnd = endChar;
		float returnx = (float)System.Convert.ToDecimal(Vector3string.Substring(startChar,endChar-1));
		//get second number (y)
		startChar = lastEnd+1;
		endChar = Vector3string.IndexOf(",", lastEnd);
		lastEnd = endChar;
		float returny = (float)System.Convert.ToDecimal(Vector3string.Substring(startChar,endChar));
		//get third number (z)
		startChar = lastEnd+1;
		endChar = Vector3string.IndexOf(",", lastEnd);
		lastEnd = endChar;
		float returnz = (float)System.Convert.ToDecimal(Vector3string.Substring(startChar,endChar));
		//build a new vector3 object using the values we've parsed
		Vector3 returnvector3 = new Vector3(returnx,returny,returnz);
		//pass back a vector3 type
		return returnvector3;
	}*/

	public void setmarkers(List<string[]>list){
		markers = list;
	}

	public void addMarker(GameObject marker){
		markerScript ms = marker.GetComponent<markerScript>();
		string[] paramaters = {marker.transform.position.ToString("F3"),ms.injury,ms.minigameText,ms.difficulty.ToString(),ms.minigame,null,ms.bPindex.ToString(),ms.ID.ToString()};
		bool add = true;
		for (int i = 0; i < markers.Count; i++) {
			string[] old = markers[i];
			if (old[6] == paramaters[6])
			{
				int temp = System.Convert.ToInt32(old[3]);
				temp += 1;
				old[3] = temp.ToString();
				add = false;
			}
		}

		if (add) {
			markers.Add (paramaters);
		}
	}

	public void setCurrentMarker(int ID){
		bool found = false;
		for (int i = 0; i < markers.Count; i++) {
			string[] old = markers[i];
			//print (pos + " = " + old[0]);
			if (ID == System.Convert.ToInt32(old[7])){
				currentMarker = i;
				found = true;
			}
		}
		if (found == false) {
			print ("NOT FOUND");
			currentMarker = -1;
		} else {
			print ("Current marker: " + currentMarker + " ID: " + ID);
		}
	}

	public int getIDforUse(){
		return nextID++;
	}

	public void deleteCurrent(){
		markers.RemoveAt (currentMarker);
	}

}
