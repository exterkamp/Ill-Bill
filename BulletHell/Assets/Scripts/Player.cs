using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public Rigidbody2D shot;
	public GameObject Explosion;
	public float fireRate;
	public float shotSpeed;
	private Rigidbody2D player;
	private float nextFire;
	
	void Start() {
		player = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Rigidbody2D shotInstance =  (Rigidbody2D) Instantiate(shot, new Vector3(transform.position.x+1, transform.position.y), new Quaternion(0,0,180,0));
			shotInstance.velocity = new Vector3(shotSpeed,0);
		}
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
	
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical);
		player.velocity = movement * speed;
	
		player.position = new Vector3 
		(
			Mathf.Clamp (player.position.x, boundary.xMin, boundary.xMax), 
			Mathf.Clamp (player.position.y, boundary.yMin, boundary.yMax),
			0.0f
		);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("EnemyShot")) {
			GameObject explosion = Instantiate (Explosion) as GameObject;
			explosion.transform.position = gameObject.transform.position;
			Destroy (gameObject);
			Destroy (other.gameObject);
			GameManager.endGame ();
		} else if (other.CompareTag ("Enemy")) {
			GameObject explosion = Instantiate (Explosion) as GameObject;
			explosion.transform.position = other.gameObject.transform.position;
			Destroy (gameObject);
			Destroy (other.gameObject);
			GameManager.endGame();
		}
	}
}
