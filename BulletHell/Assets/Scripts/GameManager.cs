using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class GameManager : MonoBehaviour {

	public GameObject enemy;
	public float spawnWait;
	public float startWait;
	
	void Start () {
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);
		while (true) {
			Instantiate (enemy);
			yield return new WaitForSeconds (spawnWait);
		}
	}

	public static void endGame() {
		Application.LoadLevel (Application.loadedLevel);
	}
}
