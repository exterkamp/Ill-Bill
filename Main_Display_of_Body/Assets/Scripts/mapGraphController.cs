using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mapGraphController : MonoBehaviour {

	public GameObject[] bodyPoints;
	public GameObject markerPrefab;
	public List<GameObject> markers;
	private string[] levels = {"FlappyBirdMain", "missileCommandMain"};
	// Use this for initialization
	public void generate(){
		GameObject bP = bodyPoints[Random.Range(0,bodyPoints.Length)];
		GameObject marker = null;
		for (int i = 0; i < markers.Count; i++) {
			markerScript ms = markers[i].GetComponent<markerScript>();
			if(ms.bodyPoint == bP){
				marker = markers[i];
				break;
			}
		}
		if (marker == null) {
			string level = levels [Random.Range (0, levels.Length)];
			int diff = 1;
			marker = (GameObject) Instantiate(markerPrefab, bP.transform.position, Quaternion.identity);
			markerScript ms = marker.GetComponent<markerScript>();
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
