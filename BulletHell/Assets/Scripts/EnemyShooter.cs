using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {
	
	public float speed;
	public Boundary boundary;
	public GameObject Explosion;
	public Rigidbody2D shot;
	public float fireRate;
	public float shotSpeed;
	private Rigidbody2D enemy;
	
	// Use this for initialization
	void Start () {
		enemy = GetComponent<Rigidbody2D> ();
		enemy.position = new Vector3 (Random.Range (boundary.xMin, boundary.xMax), Random.Range (boundary.yMin, boundary.yMax));
		enemy.velocity = new Vector3 (-speed, 0);
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
		if (other.CompareTag ("Shot")) {
			GameObject explosion = Instantiate (Explosion) as GameObject;
			explosion.transform.position = gameObject.transform.position;
			Destroy (gameObject);
			Destroy (other.gameObject);
			GameManager.incScore ();
		}
	}
}