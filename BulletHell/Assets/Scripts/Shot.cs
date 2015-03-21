using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public float speed;
	private Rigidbody2D shot;

	// Use this for initialization
	void Start () {
		shot = GetComponent<Rigidbody2D> ();
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		shot.position = new Vector3 (player.transform.position.x+1, player.transform.position.y);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		shot.velocity = new Vector3 (speed, 0);
	}
}
