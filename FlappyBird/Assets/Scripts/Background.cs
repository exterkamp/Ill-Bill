using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	public float speed = 0.1f;
	private GameManager gameController;
	// Use this for initialization
	void Start() {
		//GetComponent<Rigidbody2D>().velocity = velocity;

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

	void Update(){
		if (gameController.gameOver!=true) {
			transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
		}
	}

}
