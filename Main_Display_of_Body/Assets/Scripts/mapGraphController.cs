using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mapGraphController : MonoBehaviour {

	public GameObject[] bodyPoints;
	private string[][] bodyPointStrings = new string[16][]{ new string[]{"Headache","Jaw Fracture"},
													        new string[]{"Heart Attack","Chest pain"},
															new string[]{"Stomach Ache","Intestinal Distress"},
															new string[]{"Broken Pelvis","Bruised Pelvis"},
															new string[]{"Rolled Shoulder","Sprained Socket"},
															new string[]{"Tennis Elbow","Broken Elbow"},
															new string[]{"Bent Hand","Broken Hand"},
															new string[]{"Rolled Shoulder","Sprained Socket"},
															new string[]{"Tennis Elbow","Broken Elbow"},
															new string[]{"Bent Hand","Broken Hand"},
															new string[]{"Busted Hip","Sprained Hip"},
															new string[]{"Bent Knee","Rotated Knee"},
															new string[]{"Stubbed Toe","Broken Foot"},
															new string[]{"Busted Hip","Sprained Hip"},
															new string[]{"Bent Knee","Rotated Knee"},
															new string[]{"Stubbed Toe","Broken Foot"}};
	public GameObject markerPrefab;
	public List<GameObject> markers = null;
	private string[] levels = {"FlappyBirdMain", "missileCommandMain"};
	private string[] levelString = {"Artery Runner", "Virus Defense"};
	// Use this for initialization

	/*public void remakeMarkers(){
		//clean up array of markers
		print ("remaking");
		for (int i = 0; i < markers.Count; i++) {
			GameObject.Destroy(markers[i]);
		}
		markers = DictionaryGameState.instance.getMarkerObjects ();
	}*/


	void Awake(){
		//initialize a list of markers
		//if (DictionaryGameState.instance != null) {
		//	markers = DictionaryGameState.instance.getMarkerObjects ();
		//}
	}


	public void renderExisting(){
		getMarkerObjects(DictionaryGameState.instance.getMarkers ());
	}

	public List<GameObject> getMarkerObjects(List<string[]> strings){
		print ("getting objects");
		List<GameObject> markerOBJ = new List<GameObject> ();
		for (int i = 0; i < strings.Count; i++) {
			string[] content = strings[i];
			GameObject marker = null;
			transform.position.ToString ();
			
			marker = (GameObject)Instantiate (Resources.Load ("Marker"),Vector3FromString(content[0]), Quaternion.identity);
			//marker.SetActive(false);
			markerScript ms = marker.GetComponent<markerScript> ();
			ms.injury = content[1];
			ms.minigameText = content[2];
			ms.difficulty = System.Convert.ToInt32(content[3]);
			ms.minigame = content[4];
			ms.bodyPoint = null;
			ms.bPindex = System.Convert.ToInt32(content[6]);
			ms.ID = System.Convert.ToInt32(content[7]);
			markerOBJ.Add(marker);
		}
		return markerOBJ;
	}
	
	public Vector3 Vector3FromString(string Vector3string) {
		print ("before: " + Vector3string);
			
		string[] temp = Vector3string.Substring(1,Vector3string.Length-2).Split(',');
		float x = float.Parse(temp[0]);
		float y = float.Parse(temp[1]);
		float z = float.Parse(temp[2]);
		Vector3 rValue = new Vector3(x,y,z);

		print ("after: " + rValue.ToString("F3"));
		return rValue;
	}


	public void generate(){
		print ("generating one");
		//initialize the Dictionary
		//List<GameObject> markers = DictionaryGameState.instance.getMarkerObjects();


		int bPindex = Random.Range (0, bodyPoints.Length);
		GameObject bP = bodyPoints[bPindex];
		GameObject marker = null;
		/*for (int i = 0; i < markers.Count; i++) {
			markerScript ms = markers[i].GetComponent<markerScript>();
			if(ms.bodyPoint == bP){
				marker = markers[i];
				break;
			}
		}*/
		//if (marker == null) {
			int levelIndex = Random.Range (0, levels.Length);
			string level = levels [levelIndex];
			string levelText = levelString[levelIndex];
			int diff = 1;
			string[] bPTextFirst = bodyPointStrings[bPindex];
			string bPText = bPTextFirst[Random.Range (0, bPTextFirst.Length)];
			marker = (GameObject) Instantiate(markerPrefab, bP.transform.position, Quaternion.identity);
			//marker.transform.position = new Vector3 (marker.transform.position.x,marker.transform.position.y,0f);
			markerScript ms = marker.GetComponent<markerScript>();
			ms.injury = bPText;
			ms.minigameText = levelText;
			ms.difficulty = diff;
			ms.minigame = level;
			ms.bodyPoint = bP;
			ms.bPindex = bPindex;
			ms.ID = DictionaryGameState.instance.getIDforUse ();
		/*} else {
			markerScript ms = marker.GetComponent<markerScript>();
			if(ms.difficulty < 10){
				ms.difficulty = ms.difficulty + 1;
			}
			else{
				//propogate medical issue to connected bodyPoints
			}
		}*/

		DictionaryGameState.instance.addMarker (marker);
		GameObject.Destroy (marker);
		//remakeMarkers ();

	}
}
