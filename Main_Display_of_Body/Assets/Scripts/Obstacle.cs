using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour {
	public static Vector2 vel;
	public static float rangeMult;
	public float range = 4;
	public bool scored = false;
	
	private static float[] heights = new float[10];
	private static int heightCount=10;

	private GameManager gameController;

	void Start() { 

		if(heightCount==10){
			populateHeights();
		}

		rangeMult=heights[heightCount];
		heightCount++;

		GetComponent<Rigidbody2D>().velocity = vel;
		//transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(-range, range), transform.position.z);
		transform.position = new Vector3(transform.position.x, transform.position.y + range*rangeMult, transform.position.z);


		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameManager>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	void FixedUpdate() {
		 //GameOver
		if (gameController.gameOver==true) {
			Destroy(gameObject);
		}
		if (transform.position.x < -14.5&&!scored) {
			scored = true;
			GameManager.IncScore();
		}

	}

	private static void populateHeights(){
		heightCount=0;
		float low;
		float high;
		for(float i = 0 ; i < 10 ; i++){
			low = -1.0f+i*.2f;
			high = -1.0f+(i+1.0f)*.2f;
			heights[(int)i]=Random.Range(low,high);
		}
		
		int r;
		float t;
		for (int c = 0 ; c < 10 ; c++){
			r=Random.Range (0,10);
			t=heights[r];
			heights[r]=heights[c];
			heights[c]=t;
		}
		
	}

}