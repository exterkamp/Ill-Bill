using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public Rigidbody2D shot;
	public GameObject Explosion;
	public float fireRate;
	public float shotSpeed;
	public Sprite playerSprite;
	public Sprite playerShootingSprite;
	private Rigidbody2D player;
	private float nextFire;
	private SpriteRenderer sprite;
	private bool shooting;

	void Start() {
		player = GetComponent<Rigidbody2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		sprite.sprite = playerSprite;
		shooting = false;
	}

	void Update () {
		#if UNITY_EDITOR
		if (Input.GetButton ("Fire1")) {
			shooting = true;
			Fire ();
		}
		if (Input.GetButtonDown("Fire1")) {
			sprite.sprite = playerShootingSprite;
		} else if (Input.GetButtonUp ("Fire1")) {
			StartCoroutine (shootAnimation ());
			shooting = false;
		}
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
		#elif UNITY_ANDROID
		for (int i = 0; i < Input.touchCount; i++) {
			Touch myTouch = Input.touches[i];
			Vector3 touchLoc = Camera.main.ScreenToWorldPoint(myTouch.position);
			if (touchLoc.x >= -9 && touchLoc.x <= -6) {
				player.transform.position = Vector3.MoveTowards (player.transform.position, new Vector3
				                                                 (
					Mathf.Clamp (touchLoc.x, boundary.xMin, boundary.xMax), 
					Mathf.Clamp (touchLoc.y, boundary.yMin, boundary.yMax),
					0.0f
					), Time.deltaTime * speed);
			} else {
				shooting = true;
				Fire ();
				if (myTouch.phase == TouchPhase.Began) {
					sprite.sprite = playerShootingSprite;
				} else if (myTouch.phase == TouchPhase.Ended) {
					StartCoroutine (shootAnimation ());
					shooting = false;
				}
			}
		}
		#endif
	}

	void Fire() {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Rigidbody2D shotInstance =  (Rigidbody2D) Instantiate(shot, new Vector3(transform.position.x+1, transform.position.y), new Quaternion(0,0,180,0));
			shotInstance.velocity = new Vector3(shotSpeed,0);
		}
	}

	IEnumerator shootAnimation () {
		yield return new WaitForSeconds (0.25f);
		if (!shooting) {
			sprite.sprite = playerSprite;
		}
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
