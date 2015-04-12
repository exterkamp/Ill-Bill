using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DictionaryGameState : MonoBehaviour {
	public static DictionaryGameState instance;
	private List<string[]> markers;//0 = Vector3, 1 = injuryText, 2 = minigameText, 3 = diff, 4 = sceneName, 5 = bP, 6 = bPindex, 7 = ID
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

	public List<string[]> getMarkers(){
		return markers;
	}

	public void setmarkers(List<string[]>list){
		markers = list;
	}

	public void addMarker(string[] parameters){
		bool add = true;
		for (int i = 0; i < markers.Count; i++) {
			string[] old = markers[i];
			if (old[6] == parameters[6])
			{
				int temp = System.Convert.ToInt32(old[3]);
				if (temp != 10){
					temp += 1;
					old[3] = temp.ToString();
				}
				else{
					//spread disease
				}
				add = false;
			}
		}
		
		if (add) {
			markers.Add (parameters);
		}
	}

	[System.Obsolete("This is depracted, use stirng[] instead.")]
	public void addMarker(GameObject marker){
		markerScript ms = marker.GetComponent<markerScript>();
		string[] parameters = {marker.transform.position.ToString("F3"),ms.injury,ms.minigameText,ms.difficulty.ToString(),ms.minigame,null,ms.bPindex.ToString(),ms.ID.ToString()};
		bool add = true;
		for (int i = 0; i < markers.Count; i++) {
			string[] old = markers[i];
			if (old[6] == parameters[6])
			{
				int temp = System.Convert.ToInt32(old[3]);
				if (temp != 10){
					temp += 1;
					old[3] = temp.ToString();
				}
				add = false;
			}
		}

		if (add) {
			markers.Add (parameters);
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
			//print ("NOT FOUND");
			currentMarker = -1;
		} /*else {
			print ("Current marker: " + currentMarker + " ID: " + ID);
		}*/
	}

	public int getIDforUse(){
		return nextID++;
	}

	public void deleteCurrent(){
		markers.RemoveAt (currentMarker);
	}

	public string[] getCurrent(){
		return markers[currentMarker];
	}

}
