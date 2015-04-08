using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mapGraphController : MonoBehaviour {

	public GameObject[] bodyPoints;

	private string[] prefixes = new string[]{"There are reports of ","We are showing signs of ","There have been sightings of "};

	private string[][] bodyPointStrings = new string[16][]{ new string[]{"a Headache","a Jaw Fracture"},
													        new string[]{"Heart Attack","Chest pain"},
															new string[]{"Stomach Ache","Intestinal Distress"},
															new string[]{"a Broken Pelvis","a Bruised Pelvis"},
															new string[]{"a Rolled Shoulder","a Sprained Socket"},
															new string[]{"Tennis Elbow","a Broken Elbow"},
															new string[]{"a Bent Hand","a Broken Hand"},
															new string[]{"a Rolled Shoulder","a Sprained Socket"},
															new string[]{"Tennis Elbow","a Broken Elbow"},
															new string[]{"a Bent Hand","a Broken Hand"},
															new string[]{"a Busted Hip","a Sprained Hip"},
															new string[]{"a Bent Knee","a Rotated Knee"},
															new string[]{"a Stubbed Toe","a Broken Foot"},
															new string[]{"a Busted Hip","a Sprained Hip"},
															new string[]{"a Bent Knee","a Rotated Knee"},
															new string[]{"a Stubbed Toe","a Broken Foot"}};
	public GameObject markerPrefab;
	public List<GameObject> markers = null;
	private string[] levels = {"FlappyBirdMain", "missileCommandMain"};
	private string[] levelString = {"Artery Runner", "Virus Defense"};

	public void renderExisting(){
		getMarkerObjects(DictionaryGameState.instance.getMarkers ());
	}

	public List<GameObject> getMarkerObjects(List<string[]> strings){
		//print ("getting objects");
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
		//print ("before: " + Vector3string);
			
		string[] temp = Vector3string.Substring(1,Vector3string.Length-2).Split(',');
		float x = float.Parse(temp[0]);
		float y = float.Parse(temp[1]);
		float z = float.Parse(temp[2]);
		Vector3 rValue = new Vector3(x,y,z);

		//print ("after: " + rValue.ToString("F3"));
		return rValue;
	}


	public void generate(){
		//COMMENTED CODE KEPT JUST IN CASE, DO NOT DELETE
		//print ("generating one");
	
		int bPindex = Random.Range (0, bodyPoints.Length);
		//GameObject bP = bodyPoints[bPindex];
		//GameObject marker = null;

		int levelIndex = Random.Range (0, levels.Length);
		string level = levels [levelIndex];
		string levelText = levelString[levelIndex];
		int diff = Random.Range(1,4);
		string[] bPTextFirst = bodyPointStrings[bPindex];
		string bPText = prefixes[Random.Range(0,prefixes.Length)] + bPTextFirst[Random.Range (0, bPTextFirst.Length)];
		/*marker = (GameObject) Instantiate(markerPrefab, bP.transform.position, Quaternion.identity);
		markerScript ms = marker.GetComponent<markerScript>();
		ms.injury = bPText;
		ms.minigameText = levelText;
		ms.difficulty = diff;
		ms.minigame = level;
		ms.bodyPoint = bP;
		ms.bPindex = bPindex;
		ms.ID = DictionaryGameState.instance.getIDforUse ();*/

		string[] newMarkerParams = {bodyPoints[bPindex].transform.position.ToString("F3"),bPText,levelText, diff.ToString(),level,null,bPindex.ToString(),DictionaryGameState.instance.getIDforUse ().ToString()};

		DictionaryGameState.instance.addMarker (newMarkerParams);
		//GameObject.Destroy (marker);
	}
}
