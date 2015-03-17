using UnityEngine;
using System.Collections;

public class missileScript : MonoBehaviour {

	public Vector3 target;
	public Vector3 origin;
	public float speed;

	// Use this for initialization
	void Start () {
		float angle = Mathf.Atan2(transform.parent.gameObject.transform.position.y - target.y, transform.parent.gameObject.transform.position.x - target.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void FixedUpdate(){
		if (transform.parent.gameObject.transform.position == target){
			//this.transform.parent.gameObject
			explode ();
		}
		//Vector3 positionNext = transform.position;
		//positionNext.y = positionNext.y - 0.1f;
		//transform.position = positionNext;
		transform.parent.gameObject.transform.position = Vector3.MoveTowards(transform.parent.gameObject.transform.position, target, speed);
		Debug.DrawLine(origin,transform.position, Color.red,0,true);
	}

	void explode()
	{
		//spawn explosion object
		GameObject explosion = (GameObject)Instantiate(Resources.Load("explosion_object"));
		explosion.transform.position = this.transform.position;
		Destroy (this.transform.parent.transform.gameObject);
	}
}
