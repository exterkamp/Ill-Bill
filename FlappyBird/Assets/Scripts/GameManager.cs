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
	public double spawnRange;

	public float initSpeed;
	public float speedInc;
	public int speedIncRate;

	public int playerJumpF;

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
			
		switch(difficulty){
		case 1:
				initSpawnWait=1.8f;
				spawnTimeDec=0;
				spawnIncRate=0;
			
				initSpeed=4f;
				speedInc=0;
				speedIncRate=0;
			
				playerJumpF=330;
				spawnRange = 0;
			
				goal = 5;

			break;

		case 2:
				initSpawnWait=1.8f;
				spawnTimeDec=-0.02f;
				spawnIncRate=2;
			
				initSpeed=4f;
				speedInc=.05f;
				speedIncRate=3;
			
				playerJumpF=330;
				spawnRange = 0.1;
			
				goal = 10;

			break;

		case 3:
			initSpawnWait=2.1f;
			spawnTimeDec=0;
			spawnIncRate=0;
			
			initSpeed=4.3f;
			speedInc=0;
			speedIncRate=0;
			
			playerJumpF=340;
			spawnRange = 0.25;
			
			goal = 7;
			
			break;

		case 4:
			initSpawnWait=2.2f;
			spawnTimeDec=-0.02f;
			spawnIncRate=2;
			
			initSpeed=4.25f;
			speedInc=0.05f;
			speedIncRate=3;
			
			playerJumpF=340;
			spawnRange = 0.2;
			
			goal = 10;
			
			break;

		case 5:
			initSpawnWait=2.3f;
			spawnTimeDec=0;
			spawnIncRate=0;
			
			initSpeed=5f;
			speedInc=0;
			speedIncRate=0;
			
			playerJumpF=365;
			spawnRange = .3;
			
			goal = 10;
			
			break;

		case 6:
			initSpawnWait=2.3f;
			spawnTimeDec=-0.05f;
			spawnIncRate=2;
			
			initSpeed=5f;
			speedInc=.05f;
			speedIncRate=2;
			
			playerJumpF=365;
			spawnRange = .45;
			
			goal = 13;
			
			break;

		case 7:
			initSpawnWait=2.75f;
			spawnTimeDec=.1f;
			spawnIncRate=2;
			
			initSpeed=5.5f;
			speedInc=0;
			speedIncRate=0;
			
			playerJumpF=380;
			spawnRange = .3;
			
			goal = 13;
			
			break;

		case 8:
			initSpawnWait=2.75f;
			spawnTimeDec=.08f;
			spawnIncRate=1;
			
			initSpeed=5.5f;
			speedInc=0.05f;
			speedIncRate=2;
			
			playerJumpF=380;
			spawnRange = .2;
			
			goal = 15;
			
			break;

		case 9:
			initSpawnWait=2.7f;
			spawnTimeDec=0;
			spawnIncRate=0;
			
			initSpeed=7f;
			speedInc=0;
			speedIncRate=0;
			
			playerJumpF=400;
			spawnRange = .5;
			
			goal = 15;
			
			break;

		case 10:
			initSpawnWait=2.6f;
			spawnTimeDec=.06f;
			spawnIncRate=2;
			
			initSpeed=7f;
			speedInc=.02f;
			speedIncRate=3;
			
			playerJumpF=400;
			spawnRange = .15;
			
			goal = 15;
			
			break;

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
		Application.LoadLevel("Menu");
	}


	void Update() {
		scoreText.text = "Score: " + score;

		if(score==goal){
	
			spawnTimeDec=.22f;
			spawnIncRate=1;

			speedInc=.2f;
			speedIncRate=1;

	
		}

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

			if(difficulty<4){
				Instantiate(rocks[0]);

			} else if(difficulty<7){
				Instantiate(rocks[Random.Range (0,1)]);
				
			} else if(difficulty<9){
				Instantiate(rocks[Random.Range (1,2)]);
				
			} else{
				Instantiate(rocks[2]);
			}

			
			yield return new WaitForSeconds(spawnWait+(float)(Random.Range (-1,1)*(spawnRange)));

			if (gameOver)
			{
				yield return new WaitForSeconds(.2f);
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
