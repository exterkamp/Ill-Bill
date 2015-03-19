using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 0.1f;

	private Rigidbody2D player;
	private Vector2 vertical;
	private Vector2 horizontal;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> ();
		vertical = new Vector2 (0, speed);
		horizontal = new Vector2 (speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (Input.GetKey ("up") && screenPosition.y < 580) {
			player.MovePosition (player.position + vertical);
		} else if (Input.GetKey ("down") && screenPosition.y > 25) {
			player.MovePosition(player.position - vertical);
		} else if (Input.GetKey ("right") && screenPosition.x < 500) {
			player.MovePosition(player.position + horizontal);
		} else if (Input.GetKey ("left") && screenPosition.x > 25) {
			player.MovePosition(player.position - horizontal);
		}
	}
}
