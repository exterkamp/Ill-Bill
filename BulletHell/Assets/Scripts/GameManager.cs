using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class GameManager : MonoBehaviour {

	public GameObject enemy;
	public GameObject enemyShooter;
	public float initEnemySpawnWait;
	public float initEnemyShooterSpawnWait;
	public Text scoreText;

	private static float enemySpawnWait;
	private static float enemyShooterSpawnWait;
	private static int score = 0;
	
	void Start () {
		score = 0;
		enemySpawnWait = initEnemySpawnWait;
		enemyShooterSpawnWait = initEnemyShooterSpawnWait;
		scoreText.text = "Score: " + score;
		StartCoroutine (SpawnEnemyWaves ());
		StartCoroutine (SpawnEnemyShooterWaves ());
	}

	void Update() {
		scoreText.text = "Score: " + score;
	}
	
	IEnumerator SpawnEnemyWaves () {
		while (true) {
			Instantiate (enemy);
			yield return new WaitForSeconds (enemySpawnWait);
		}
	}

	IEnumerator SpawnEnemyShooterWaves() {
		while (true) {
			Instantiate (enemyShooter);
			yield return new WaitForSeconds (enemyShooterSpawnWait);
		}
	}

	public static void incScore() {
		score++;
		if (score % 10 == 0 && enemySpawnWait >= 0.2f) {
			enemySpawnWait -= 0.1f;
		}
		if (score % 10 == 0 && enemyShooterSpawnWait >= 0.2f) {
			enemyShooterSpawnWait -= 0.1f;
		}
	}

	public static void endGame() {
		Application.LoadLevel (Application.loadedLevel);
	}
}
