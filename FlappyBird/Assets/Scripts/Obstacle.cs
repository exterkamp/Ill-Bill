using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour {
	public static Vector2 vel;
	public float range = 4;
	public bool scored = false;

	private GameManager gameController;

	void Start() { 
		GetComponent<Rigidbody2D>().velocity = vel;
		transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(-range, range), transform.position.z);

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
}