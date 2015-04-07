using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mapGraphController : MonoBehaviour {

	public GameObject[] bodyPoints;
	private string[][] bodyPointStrings = new string[16][]{  new string[]{"Headache","Jaw Fracture"},
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
	public List<GameObject> markers;
	private string[] levels = {"FlappyBirdMain", "missileCommandMain"};
	private string[] levelString = {"Artery Runner", "Virus Defense"};
	// Use this for initialization


	public void generate(){
		int bPindex = Random.Range (0, bodyPoints.Length);
		GameObject bP = bodyPoints[bPindex];
		GameObject marker = null;
		for (int i = 0; i < markers.Count; i++) {
			markerScript ms = markers[i].GetComponent<markerScript>();
			if(ms.bodyPoint == bP){
				marker = markers[i];
				break;
			}
		}
		if (marker == null) {
			int levelIndex = Random.Range (0, levels.Length);
			string level = levels [levelIndex];
			string levelText = levelString[levelIndex];
			int diff = 1;
			string[] bPTextFirst = bodyPointStrings[bPindex];
			string bPText = bPTextFirst[Random.Range (0, bPTextFirst.Length)];
			marker = (GameObject) Instantiate(markerPrefab, bP.transform.position, Quaternion.identity);
			markerScript ms = marker.GetComponent<markerScript>();
			ms.injury = bPText;
			ms.minigameText = levelText;
			ms.difficulty = diff;
			ms.minigame = level;
			ms.bodyPoint = bP;
		} else {
			markerScript ms = marker.GetComponent<markerScript>();
			if(ms.difficulty < 10){
				ms.difficulty = ms.difficulty + 1;
			}
			else{
				//propogate medical issue to connected bodyPoints
			}
		}
	}
}
