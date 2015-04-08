using UnityEngine;
using System.Collections;

public class EnemyGroup : MonoBehaviour {

	public Boundary boundary;
	public Rigidbody2D enemy1;
	public Rigidbody2D enemy2;
	public Rigidbody2D enemy3;
	private Rigidbody2D enemy1rb2d;
	private Rigidbody2D enemy2rb2d;
	private Rigidbody2D enemy3rb2d;
	private Vector3 position;
	private Vector3 velocity;
	private bool first = true;
	// Use this for initialization
	void Start () {
		first = true;
		enemy1rb2d = (Rigidbody2D) Instantiate (enemy1);
		enemy2rb2d = (Rigidbody2D) Instantiate (enemy2);
		enemy3rb2d = (Rigidbody2D) Instantiate (enemy3);
		position = new Vector3 (Random.Range (boundary.xMin, boundary.xMax), Random.Range (boundary.yMin, boundary.yMax));
		velocity = new Vector3 (-Random.Range (EnemyShooter.getMinSpeed (), EnemyShooter.getMaxSpeed ()), 0);
	}

	// Update is called once per frame
	void Update () {
		if (enemy1rb2d != null && enemy2rb2d != null && enemy3rb2d != null && first) {
			int formation = (int)Mathf.Floor (Random.Range (0,3));
			if (formation == 0) {
				enemy1rb2d.position = position;
				enemy1rb2d.velocity = velocity;
				enemy2rb2d.position = new Vector3(position.x+1f, position.y+1f);
				enemy2rb2d.velocity = velocity;
				enemy3rb2d.position = new Vector3(position.x+1f, position.y-1f);
				enemy3rb2d.velocity = velocity;
			} else if (formation == 1) {
				enemy1rb2d.position = position;
				enemy1rb2d.velocity = velocity;
				enemy2rb2d.position = new Vector3(position.x-1f, position.y-1f);
				enemy2rb2d.velocity = velocity;
				enemy3rb2d.position = new Vector3(position.x+1f, position.y+1f);
				enemy3rb2d.velocity = velocity;
			} else {
				enemy1rb2d.position = position;
				enemy1rb2d.velocity = velocity;
				enemy2rb2d.position = new Vector3(position.x-1f, position.y+1f);
				enemy2rb2d.velocity = velocity;
				enemy3rb2d.position = new Vector3(position.x+1f, position.y-1f);
				enemy3rb2d.velocity = velocity;
			}
			first = false;
		}
	}
}
