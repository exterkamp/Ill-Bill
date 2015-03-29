using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Boundary boundary;
	public GameObject Explosion;
	private Rigidbody2D enemy;
	private static float minSpeed;
	private static float maxSpeed;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<Rigidbody2D> ();
		enemy.position = new Vector3 (Random.Range (boundary.xMin, boundary.xMax), Random.Range (boundary.yMin, boundary.yMax));
		enemy.velocity = new Vector3 (-Random.Range (minSpeed, maxSpeed), 0);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Shot")) {
			GameObject explosion = Instantiate (Explosion) as GameObject;
			explosion.transform.position = gameObject.transform.position;
			Destroy (gameObject);
			Destroy (other.gameObject);
			DictionaryMinigame.instance.incScore (1);
			GameManager.editSpawnRate ();
		}
	}

	public static void setSpeed(float min, float max) {
		minSpeed = min;
		maxSpeed = max;
	}
}
