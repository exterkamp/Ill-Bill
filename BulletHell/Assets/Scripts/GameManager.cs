using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class GameManager : MonoBehaviour {

	public GameObject enemy;
	public float initSpawnWait;
	public float startWait;
	public Text scoreText;

	private static float spawnWait;
	private static int score = 0;
	
	void Start () {
		score = 0;
		spawnWait = initSpawnWait;
		scoreText.text = "Score: " + score;
		StartCoroutine (SpawnWaves ());
	}

	void Update() {
		scoreText.text = "Score: " + score;
	}
	
	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);
		while (true) {
			Instantiate (enemy);
			yield return new WaitForSeconds (spawnWait);
		}
	}

	public static void incScore() {
		score++;
		if (score % 10 == 0 && spawnWait >= 0.2f) {
			spawnWait -= 0.1f;
		}
	}

	public static void endGame() {
		Application.LoadLevel (Application.loadedLevel);
	}
}
