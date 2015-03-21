using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public GameObject Explosion;
	private Rigidbody2D enemy;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<Rigidbody2D> ();
		enemy.position = new Vector3 (Random.Range (boundary.xMin, boundary.xMax), Random.Range (boundary.yMin, boundary.yMax));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		enemy.velocity = new Vector3 (-speed, 0);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Shot")) {
			GameObject explosion = Instantiate (Explosion) as GameObject;
			explosion.transform.position = gameObject.transform.position;
			Destroy (gameObject);
			Destroy (other.gameObject);
		} else if (other.CompareTag ("Player")) {
			GameObject explosion = Instantiate (Explosion) as GameObject;
			explosion.transform.position = other.gameObject.transform.position;
			Destroy (gameObject);
			Destroy (other.gameObject);
			GameManager.endGame();
		}
	}
}
