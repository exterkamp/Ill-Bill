using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class spawnControllerScript : MonoBehaviour {
	
	public GameObject[] prefabs;
	public GameObject[] spawnPoints;
	//public GameObject[] targetPoints;
	public GameObject[] siloPoints;

	public int missilesRemaining;
	//DictionaryMinigame DM;
	Text GUINumberMissileRemaining;
	Text scoreText;

	//
	float enemyMissileSpeed;
	float friendlyMissileSpeed;
	float clusterChance;

	// Use this for initialization
	void Start () {
		//setup difficulty
		GameObject g = GameObject.FindGameObjectWithTag ("dictionary_minigame");
		DictionaryMinigame DM = g.GetComponent<DictionaryMinigame> ();
		int difficulty = DM.getDiff ();

		if (difficulty == 1) {
			missilesRemaining = 15;
			enemyMissileSpeed = 0.020f;
			friendlyMissileSpeed = 0.2f;
			clusterChance = 0.0f;
		} else if (difficulty == 2) {
			missilesRemaining = 15;
			enemyMissileSpeed = 0.025f;
			friendlyMissileSpeed = 0.2f;
			clusterChance = 0.0001f;
		} else if (difficulty == 3) {
			missilesRemaining = 15;
			enemyMissileSpeed = 0.025f;
			friendlyMissileSpeed = 0.15f;
			clusterChance = 0.0005f;
		} else if (difficulty == 4) {
			missilesRemaining = 25;
			enemyMissileSpeed = 0.025f;
			friendlyMissileSpeed = 0.175f;
			clusterChance = 0.0075f;
		} else if (difficulty == 5) {
			missilesRemaining = 25;
			enemyMissileSpeed = 0.025f;
			friendlyMissileSpeed = 0.1f;
			clusterChance = 0.001f;
		} else if (difficulty == 6) {
			missilesRemaining = 25;
			enemyMissileSpeed = 0.0275f;
			friendlyMissileSpeed = 0.1f;
			clusterChance = 0.001f;
		} else if (difficulty == 7) {
			missilesRemaining = 30;
			enemyMissileSpeed = 0.03f;
			friendlyMissileSpeed = 0.1f;
			clusterChance = 0.005f;
		} else if (difficulty == 8) {
			missilesRemaining = 30;
			enemyMissileSpeed = 0.0325f;
			friendlyMissileSpeed = 0.075f;
			clusterChance = 0.006f;
		} else if (difficulty == 9) {
			missilesRemaining = 30;
			enemyMissileSpeed = 0.035f;
			friendlyMissileSpeed = 0.085f;
			clusterChance = 0.0075f;
		} else {
			missilesRemaining = 35;
			enemyMissileSpeed = 0.04f;
			friendlyMissileSpeed = 0.1f;
			clusterChance = 0.008f;
		}

		GUINumberMissileRemaining = Camera.main.transform.FindChild("Canvas").transform.FindChild("numberText").gameObject.GetComponent<Text>();
		scoreText = Camera.main.transform.FindChild("Canvas").transform.FindChild("Score").gameObject.GetComponent<Text>();
		//DM = GameObject.FindGameObjectWithTag ("dictionary_minigame").GetComponent<DictionaryMinigame> ();

		StartCoroutine (missileLaunch());
		//missilesRemaining = 10;

	}
	
	// Update is called once per frame
	void Update () {
		GUINumberMissileRemaining.text = missilesRemaining.ToString ();
		if (Input.GetMouseButtonDown (0)) {
			//get silo
			Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPos.z = 0f;
			GameObject silo = findSiloFire(targetPos);
			//CHECK NULL
			if (silo != null){
				Vector3 newPos = silo.transform.position;
				//dec silo
				silo.GetComponentInChildren<SiloController>().decAmmo();

				GameObject newMissile = (GameObject) Instantiate(prefabs[Random.Range (0,prefabs.Length)], newPos, new Quaternion(0,0,0,0));
				missileScript m = newMissile.GetComponentInChildren<missileScript>();//.target = new Vector3(1,0,0);

				m.target = targetPos;
				m.speed = friendlyMissileSpeed;
				m.clusterChance = -1.0f;
				//print(m.target.x + "," + m.target.y);
				newMissile.tag = "friendlyMissile";
			}

		}
		
		//set score
		scoreText.text = "Score: " + GameObject.FindGameObjectWithTag ("dictionary_minigame").GetComponent<DictionaryMinigame> ().getScore ().ToString();

		//check win conditions
		int state = checkWinConditions ();
		if (state == 1) {
			setWinLoss(true);
		}
		if (state == 2) {
			setWinLoss(false);
		}
		if (state != 0) {
			//calculate final score for cities
			incScore(checkFinalCityScores());

			Application.LoadLevel("splashMenu");
			
		}

	}

	public void incScore(int scoreInc){
		GameObject.FindGameObjectWithTag ("dictionary_minigame").GetComponent<DictionaryMinigame> ().setScore (GameObject.FindGameObjectWithTag ("dictionary_minigame").GetComponent<DictionaryMinigame> ().getScore () + scoreInc);
	}

	public void setWinLoss(bool WL){
		GameObject.FindGameObjectWithTag ("dictionary_minigame").GetComponent<DictionaryMinigame> ().setWL (WL);
	}

	int checkFinalCityScores(){
		int score = 0;
		foreach (GameObject g in siloPoints) {
			if (g.transform.FindChild("city").GetComponent<SiloController>().state != SiloController.siloState.ruins){
				score += 200;
			}
		}
		return score;
	}


	int checkWinConditions(){
		//0 means nothing is wrong, 1 is win, 2 is lose
		int gameOver = 0;

		//print (missilesRemaining);
		//print (GameObject.FindGameObjectsWithTag("enemyMissile").Length);
		if (missilesRemaining == 0 && GameObject.FindGameObjectsWithTag("enemyMissile").Length == 0){
			gameOver = 1;
		}

		//if last missile blows you up, you lose still :( so check after checking if all missiles gone
		int count = 0;
		foreach (GameObject g in siloPoints) {
			if (g.transform.FindChild("city").GetComponent<SiloController>().state == SiloController.siloState.ruins){
				count++;
			}
		}
		if (count == siloPoints.Length){
			gameOver = 2;
		}


		return gameOver;
	}


	GameObject findSiloFire(Vector3 targetPos){
		float curDistance = 1000f;
		GameObject curSilo = null;
		//read ammo cap
		foreach (GameObject g in siloPoints){
			SiloController s = g.GetComponentInChildren<SiloController>();
			if (s.canSiloFire() && (Vector3.Distance (targetPos, g.transform.position)) < curDistance){
				curSilo = g;
				curDistance = Vector3.Distance (targetPos, g.transform.position);
			}

		}
		return curSilo;
	}

	public GameObject findSiloTarget(){
		//assume there is a target left
		bool canTarget = false;

		foreach (GameObject g in siloPoints) {
			if (g.transform.FindChild("city").GetComponent<SiloController>().state != SiloController.siloState.ruins){
				canTarget = true;
			}
		}

		GameObject targetSilo = null;

		if (canTarget) {
			while (targetSilo == null){
				GameObject g = siloPoints[Random.Range (0,siloPoints.Length)];
				if (g.transform.FindChild("city").GetComponent<SiloController>().state != SiloController.siloState.ruins){
					targetSilo = g;
				}
			}
		}

		return targetSilo;
		//siloPoints[Random.Range (0,siloPoints.Length)].transform.position;
		
		
	}
	
	//fixed update
	void FixedUpdate(){

	}

	IEnumerator missileLaunch()
	{
		while (true) {
			//new Pos
			GameObject target = findSiloTarget();

			if (target != null && missilesRemaining > 0)
			{
				Vector3 newPos = spawnPoints [Random.Range (0,spawnPoints.Length)].transform.position;
				newPos.x = newPos.x + Random.Range(0f,2f) - Random.Range(-2f,0f);
				//print (newPos.x);
				//spawn a missile
				GameObject newMissile = (GameObject) Instantiate(prefabs[Random.Range (0,prefabs.Length)], newPos, new Quaternion(0,0,0,0));
				missileScript m = newMissile.GetComponentInChildren<missileScript>();//.target = new Vector3(1,0,0);

				m.target = target.transform.position;


				m.speed = enemyMissileSpeed;
				m.clusterChance = clusterChance;
				newMissile.tag = "enemyMissile";
				missilesRemaining -= 1;
			}
			yield return new WaitForSeconds(Random.Range(1f,3f));

			
		}
	}

	public void blowUpTarget(GameObject targetToBlowUp){
		//targetToBlowUp
	}

}
