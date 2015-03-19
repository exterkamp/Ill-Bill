using UnityEngine;

public class Player : MonoBehaviour {
	// The force which is added when the player jumps
	// This can be changed in the Inspector window
	public Vector2 jumpForce = new Vector2(0, 300);
	public int tilt;
	private GameManager gameController;
	private bool dead;

	void Start(){
		dead = false;
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

	void Update () {
		// Jump
		if (Input.GetMouseButtonDown(0) && !dead) {
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GetComponent<Rigidbody2D>().AddForce(jumpForce);
		}

		// Die by being off screen
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y < 0 && !dead) {
			dead = true;
			Die();
		}

		if (screenPosition.y < -3) {
			Destroy(gameObject);
		}

		if(!dead){
		GetComponent<Rigidbody2D>().position = new Vector2(-3, (float)(Mathf.Clamp (GetComponent<Rigidbody2D>().position.y, -6f, 4.7f)));

		if(GetComponent<Rigidbody2D>().position.y==4.7f){
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

		GetComponent<Rigidbody2D>().rotation=(GetComponent<Rigidbody2D>().velocity.y*tilt);
		}else{
			GetComponent<Rigidbody2D>().rotation=(GetComponent<Rigidbody2D>().velocity.y*tilt*250);
		}
	}

	// Die by collision
	void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.CompareTag("obstacle")){
			dead = true;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 425));
			Die();
		}
	}
	
	void Die() {
		gameController.GameOver();
	}
}