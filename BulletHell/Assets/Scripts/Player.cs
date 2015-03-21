using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public GameObject shot;
	public float fireRate;
	private Rigidbody2D player;
	private float nextFire;
	
	void Start() {
		player = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot);
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
}
