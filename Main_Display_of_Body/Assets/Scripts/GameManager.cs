using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public Text scoreText;
	public Text restartText;
	public Text gameOverText;
	public Text goalText;
	public Text attemptText;


	public float startWait;
	public float initSpawnWait;
	public float spawnTimeDec;
	public int spawnIncRate;

	public float initSpeed;
	public float speedInc;
	public int speedIncRate;

	public GameObject[] rocks;
	public GameObject backgrounds;
	public GameObject FlappyDictionary;

	private static int score = 0;

	public bool gameOver;
	public bool restart;
	private int prevSpawnInc;
	private int prevSpeedInc;
	private float spawnWait;

	private GameObject g;
	private DictionaryMinigame DM;
	FlappyDictionary FD;
	private int difficulty;
	private int goal;

	void Start()
	{

		if (GameObject.FindGameObjectsWithTag("dictionary_flappy").Length == 0)
			Instantiate(FlappyDictionary);


		g = GameObject.FindGameObjectWithTag ("dictionary_minigame");
		DM = g.GetComponent<DictionaryMinigame> ();
		g = GameObject.FindGameObjectWithTag ("dictionary_flappy");
		FD = g.GetComponent<FlappyDictionary> ();
		difficulty = DM.getDiff ();
		goal = 15;

			initSpawnWait=(float)(-0.15*difficulty+3.1);
			spawnTimeDec=(float)(-0.02*difficulty+0.3);
			
			initSpeed=(float)(0.2667*difficulty+2.733);
			speedInc=(float)(-0.02*difficulty+0.3);

			if(difficulty<6){
				spawnIncRate=3;
				speedIncRate=3;
			}else{
				spawnIncRate=2;
				speedIncRate=2;
			}





		attemptText.text= "Attempts: "+FD.getAttempts();
		goalText.text = "Goal: " + goal;
		gameOver = false;
		restart = false;
		score = 0;
		prevSpawnInc=0;
		prevSpeedInc=0;
		spawnWait=initSpawnWait;
		Obstacle.vel=new Vector2(-initSpeed, 0);
		restartText.text = "";
		gameOverText.text = "";
		StartCoroutine (CreateObstacle ());
		StartCoroutine (CreateBackground ());
	}






	public static void IncScore(){
		score++;

	}

	public static void IncScore(int i){
		score+=i;
	
	}
	
	public void GameOver(){
		gameOver = true;
		gameOverText.text = "Game Over! Score = "+score;

		if(score>DM.getScore ()){
			DM.setScore (score);
		}

		if(score>=goal){
			DM.setWL (true);
			LoadMenu();
		}else{
			DM.setWL (false);
		}

		if(FD.getAttempts()>=1){
			FD.decAttempts();
			attemptText.text= "Attempts: "+FD.getAttempts();
		}


		prevSpawnInc=0;
		prevSpeedInc=0;

	}

	void LoadMenu(){
		//FD.setAttempts(3);
		Destroy(FD.gameObject);
		Application.LoadLevel("BodyMap");
	}


	void Update() {
		scoreText.text = "Score: " + score;

		if(score>=prevSpawnInc+spawnIncRate){
			prevSpawnInc=score;
			if(spawnWait-spawnTimeDec>.5){
				spawnWait-=spawnTimeDec;
			}

		}

		if(score>=prevSpeedInc+speedIncRate){
			prevSpeedInc=score;

			Obstacle.vel.x-=speedInc;
		
			
		}

		if (restart )
		{
			if (Input.GetMouseButtonDown(0))
			{
				if(FD.getAttempts()>=1){
					Application.LoadLevel (Application.loadedLevel);
				}else{
					LoadMenu();
				}

			}
		}



	}
	

	IEnumerator CreateBackground(){
		
		while(true){
			Instantiate(backgrounds);
			yield return new WaitForSeconds(9.7f);

			if (gameOver)
				break;

		}
		
	}


	IEnumerator CreateObstacle(){
		yield return new WaitForSeconds(startWait);
		
		while(true){
			
			Instantiate(rocks[Random.Range (0,rocks.Length)]);
			
			yield return new WaitForSeconds(spawnWait+(float)(Random.Range (-1,1)*.1));

			if (gameOver)
			{
				yield return new WaitForSeconds(.25f);
				restart = true;
				if(FD.getAttempts()<1){
					restartText.text = "Tap to Quit";
				}else{
					restartText.text = "Tap to Restart";
				}
				break;
			}
		}
	}



}
