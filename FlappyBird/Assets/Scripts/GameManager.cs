using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public Text scoreText;
	public Text fpsText;
	public Text restartText;
	public Text gameOverText;


	public float startWait;
	public float initSpawnWait;
	public float spawnTimeDec;
	public int spawnIncRate;

	public float initSpeed;
	public float speedInc;
	public int speedIncRate;

	public GameObject[] rocks;
	public GameObject backgrounds;


	private static int score = 0;
	public bool gameOver;
	public bool restart;
	private int prevSpawnInc=0;
	private int prevSpeedInc=0;
	private float spawnWait;



	
	/// <fps>


	private  float updateInterval = 0.5F;
	
	private float accum   = 0; // FPS accumulated over the interval
	private int   frames  = 0; // Frames drawn over the interval
	private float timeleft; // Left time for current interval
	
	void Start()
	{

		gameOver = false;
		restart = false;
		score = 0;
		spawnWait=initSpawnWait;
		Obstacle.vel=new Vector2(-initSpeed, 0);
		restartText.text = "";
		gameOverText.text = "";
		fpsText.text = System.String.Format("{0:F2} FPS",60.00f);
		timeleft = updateInterval;  
		StartCoroutine (CreateObstacle ());
		StartCoroutine (CreateBackground ());
	}
	
	///   </fps>





	public static void IncScore(){
		score++;

	}

	public static void IncScore(int i){
		score+=i;
	
	}
	
	public void GameOver(){
		gameOver = true;
		gameOverText.text = "Game Over! Score = "+score;



		prevSpawnInc=0;
		prevSpeedInc=0;

	}
	

	void Update() {
		scoreText.text = "Score: " + score;

		if(score>=prevSpawnInc+spawnIncRate){
			prevSpawnInc=score;
			if(spawnWait-spawnTimeDec>1){
				spawnWait-=spawnTimeDec;
			}

		}

		if(score>=prevSpeedInc+speedIncRate){
			prevSpeedInc=score;
			//if(Obstacle.vel.x-speedInc<-6){
			Obstacle.vel.x-=speedInc;
			//}
			
		}

		/// <fps>

		timeleft -= Time.deltaTime;
		accum += Time.timeScale/Time.deltaTime;
		++frames;
		
		// Interval ended - updatetext and start new interval
		if( timeleft <= 0.0 )
		{
			// display two fractional digits (f2 format)
			float fps = accum/frames;
			string format = System.String.Format("{0:F2} FPS",fps);
			fpsText.text = format;
			
			if(fps < 30)
				fpsText.material.color = Color.yellow;
			else 
				if(fps < 10)
					fpsText.material.color = Color.red;
			else
				fpsText.material.color = Color.green;
			//	DebugConsole.Log(format,level);
			timeleft = updateInterval;
			accum = 0.0F;
			frames = 0;
		}

		///</fps>



		///<restart>

		if (restart)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}


		///</restart>




	}




	IEnumerator CreateBackground(){
		
		while(true){
			Instantiate(backgrounds);
			yield return new WaitForSeconds(9.9f);

			if (gameOver)
				break;

		}
		
	}


	IEnumerator CreateObstacle(){
		yield return new WaitForSeconds(startWait);
		
		while(true){
			
			Instantiate(rocks[Random.Range (0,rocks.Length)]);
			
			yield return new WaitForSeconds(spawnWait+(float)(Random.Range (-1,1)*.25));

			if (gameOver)
			{
				yield return new WaitForSeconds(.75f);
				restart = true;
				restartText.text = "Tap to Restart";
				break;
			}
		}
	}






}
