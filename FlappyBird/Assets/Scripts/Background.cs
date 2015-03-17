using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	public Vector2 velocity = new Vector2(-2, 0);
	private GameManager gameController;
	// Use this for initialization
	void Start() {
		GetComponent<Rigidbody2D>().velocity = velocity;

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
		if (gameController.gameOver==true) {
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}
	}

}
