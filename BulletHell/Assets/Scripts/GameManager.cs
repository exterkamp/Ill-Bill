﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class GameManager : MonoBehaviour {

	public GameObject enemy;
	public GameObject enemyShooter;
	public GameObject enemyGroup;
	public Text scoreText;

	private static float enemySpawnWait;
	private static float enemyShooterSpawnWait;
	private static float enemyGroupSpawnWait;
	
	void Start () {
		scoreText.text = "Score: " + DictionaryMinigame.instance.getScore ().ToString ();
		switch (DictionaryMinigame.instance.getDiff ()) {
		case 10:
			Enemy.setSpeed (3.25f, 5.25f);
			EnemyShooter.setSpeed (3.25f, 5.25f);
			EnemyShooter.setFireRate (0.5f, 0.75f);
			EnemyShooter.setFireSpeed (10f);
			enemySpawnWait = 0.2f;
			enemyShooterSpawnWait = 1f;
			enemyGroupSpawnWait = 1f;
			break;
		case 9:
			Enemy.setSpeed (3f, 5f);
			EnemyShooter.setSpeed (3f, 5f);
			EnemyShooter.setFireRate (0.65f, 1f);
			EnemyShooter.setFireSpeed (9.5f);
			enemySpawnWait = 0.3f;
			enemyShooterSpawnWait = 1.2f;
			enemyGroupSpawnWait = 2f;
			break;
		case 8:
			Enemy.setSpeed (2.75f, 4.75f);
			EnemyShooter.setSpeed (2.75f, 4.75f);
			EnemyShooter.setFireRate (0.8f, 1.25f);
			EnemyShooter.setFireSpeed (9f);
			enemySpawnWait = 0.4f;
			enemyShooterSpawnWait = 1.4f;
			enemyGroupSpawnWait = 3f;
			break;
		case 7:
			Enemy.setSpeed (2.5f, 4.5f);
			EnemyShooter.setSpeed (2.5f, 4.5f);
			EnemyShooter.setFireRate (0.95f, 1.5f);
			EnemyShooter.setFireSpeed (8.5f);
			enemySpawnWait = 0.5f;
			enemyShooterSpawnWait = 1.6f;
			enemyGroupSpawnWait = 4f;
			break;
		case 6:
			Enemy.setSpeed (2.25f, 4.25f);
			EnemyShooter.setSpeed (2.25f, 4.25f);
			EnemyShooter.setFireRate (1.1f, 1.75f);
			EnemyShooter.setFireSpeed (8f);
			enemySpawnWait = 0.6f;
			enemyShooterSpawnWait = 1.8f;
			enemyGroupSpawnWait = 5f;
			break;
		case 5:
			Enemy.setSpeed (2.0f, 4.0f);
			EnemyShooter.setSpeed (2.0f, 4.0f);
			EnemyShooter.setFireRate (1.25f, 2f);
			EnemyShooter.setFireSpeed (7.5f);
			enemySpawnWait = 0.7f;
			enemyShooterSpawnWait = 2f;
			enemyGroupSpawnWait = 6f;
			break;
		case 4:
			Enemy.setSpeed (1.75f, 3.75f);
			EnemyShooter.setSpeed (1.75f, 3.75f);
			EnemyShooter.setFireRate (1.4f, 2.25f);
			EnemyShooter.setFireSpeed (7f);
			enemySpawnWait = 0.8f;
			enemyShooterSpawnWait = 2.2f;
			enemyGroupSpawnWait = 7f;
			break;
		case 3:
			Enemy.setSpeed (1.5f, 3.5f);
			EnemyShooter.setSpeed (1.5f, 3.5f);
			EnemyShooter.setFireRate (1.65f, 2.5f);
			EnemyShooter.setFireSpeed (6.5f);
			enemySpawnWait = 0.9f;
			enemyShooterSpawnWait = 2.4f;
			enemyGroupSpawnWait = 8f;
			break;
		case 2:
			Enemy.setSpeed (1.25f, 3.25f);
			EnemyShooter.setSpeed (1.25f, 3.25f);
			EnemyShooter.setFireRate (1.8f, 2.75f);
			EnemyShooter.setFireSpeed (6f);
			enemySpawnWait = 1f;
			enemyShooterSpawnWait = 2.6f;
			enemyGroupSpawnWait = 9f;
			break;
		case 1:
			Enemy.setSpeed (1f, 3f);
			EnemyShooter.setSpeed (1f, 3f);
			EnemyShooter.setFireRate (1.95f, 3f);
			EnemyShooter.setFireSpeed (5.5f);
			enemySpawnWait = 1.1f;
			enemyShooterSpawnWait = 2.8f;
			enemyGroupSpawnWait = 10f;
			break;
		}
		StartCoroutine (SpawnEnemyWaves ());
		StartCoroutine (SpawnEnemyShooterWaves ());
		StartCoroutine (SpawnEnemyGroupWaves ());
	}

	void Update() {
		scoreText.text = "Score: " + DictionaryMinigame.instance.getScore().ToString ();
	}
	
	IEnumerator SpawnEnemyWaves () {
		while (true) {
			yield return new WaitForSeconds (enemySpawnWait);
			Instantiate (enemy);
		}
	}

	IEnumerator SpawnEnemyShooterWaves() {
		while (true) {
			yield return new WaitForSeconds (enemyShooterSpawnWait);
			Instantiate (enemyShooter);
		}
	}

	IEnumerator SpawnEnemyGroupWaves() {
		while (true) {
			yield return new WaitForSeconds(enemyGroupSpawnWait);
			Instantiate (enemyGroup);
		}
	}

	public static void editSpawnRate() {
		if (DictionaryMinigame.instance.getScore () % 10 == 0 && enemySpawnWait >= 0.1f) {
			enemySpawnWait -= 0.05f;
		}
		if (DictionaryMinigame.instance.getScore () % 10 == 0 && enemyShooterSpawnWait >= 0.1f) {
			enemyShooterSpawnWait -= 0.05f;
		}
	}

	public static void endGame() {
		if (DictionaryMinigame.instance.getScore () >= DictionaryMinigame.instance.getGoal ()) {
			DictionaryMinigame.instance.setWL (true);
		} else {
			DictionaryMinigame.instance.setWL (false);
		}
		Application.LoadLevel ("SplashMenu");
	}
}
