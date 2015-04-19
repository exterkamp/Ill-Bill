using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {
	
	public Boundary boundary;
	public GameObject Explosion;
	public Rigidbody2D shot;
	private Rigidbody2D enemy;
	private float fireRate;
	private float speed;
	private static float minSpeed;
	private static float maxSpeed;
	private static float minFireRate;
	private static float maxFireRate;
	private static float shotSpeed;
	
	// Use this for initialization
	void Start () {
		enemy = GetComponent<Rigidbody2D> ();
		enemy.position = new Vector3 (Random.Range (boundary.xMin, boundary.xMax), Random.Range (boundary.yMin, boundary.yMax));
		speed = Random.Range (minSpeed, maxSpeed);
		enemy.velocity = new Vector3 (-speed, 0);
		fireRate = Random.Range (minFireRate, maxFireRate);
		StartCoroutine (FireShots());
	}
	
	IEnumerator FireShots() {
		while (true) {
			yield return new WaitForSeconds(fireRate);
			Rigidbody2D shotInstance =  (Rigidbody2D) Instantiate(shot, new Vector3(transform.position.x-1, transform.position.y), Quaternion.identity);
			shotInstance.velocity = new Vector3(-shotSpeed,0);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Shot") && enemy.position.x < 8.5f) {
			GameObject explosion = Instantiate (Explosion) as GameObject;
			explosion.transform.position = gameObject.transform.position;
			Destroy (gameObject);
			Destroy (other.gameObject);
			DictionaryMinigame.instance.incScore (1);
			GameManagerBH.editSpawnRate ();
		}
	}
	
	public static void setSpeed(float min, float max) {
		minSpeed = min;
		maxSpeed = max;
	}
	
	public static void setFireRate(float min, float max) {
		minFireRate = min;
		maxFireRate = max;
	}
	
	public static void setFireSpeed(float speed) {
		shotSpeed = speed;
	}
	
	public static float getMinSpeed() {
		return minSpeed;
	}
	
	public static float getMaxSpeed() {
		return maxSpeed;
	}
}