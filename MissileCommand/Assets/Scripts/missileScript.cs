using UnityEngine;
using System.Collections;

public class missileScript : MonoBehaviour {

	public Vector3 target;
	public Vector3 origin;
	public float speed;
	public float clusterChance;
	private LineRenderer lr;

	// Use this for initialization
	void Start () {
		float angle = Mathf.Atan2(transform.parent.gameObject.transform.position.y - target.y, transform.parent.gameObject.transform.position.x - target.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		origin = transform.position;
		lr = transform.parent.FindChild ("missile trail").GetComponent<LineRenderer> ();
		lr.enabled = false;
		lr.SetPosition (0, origin);
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
		//Debug.DrawLine(origin,transform.position, Color.red,0,true);
		lr.SetPosition (1, new Vector3(transform.position.x,transform.position.y,transform.position.z + 1f));
		lr.enabled = true;
		if (Random.Range (0f,1f) < clusterChance) {
			cluster ();
		}
	}

	void cluster(){
		//print ("cluster");

		GameObject target = GameObject.FindGameObjectWithTag("pointController").GetComponent<spawnControllerScript>().findSiloTarget();

		if (target != null)
		{
			Vector3 newPos = transform.position;
			//spawn a missile
			GameObject newMissile = (GameObject) Instantiate(Resources.Load("missile"), newPos, new Quaternion(0,0,0,0));
			missileScript m = newMissile.GetComponentInChildren<missileScript>();//.target = new Vector3(1,0,0);
			
			m.target = target.transform.position;
			
			
			m.speed = speed;
			m.clusterChance = clusterChance / 2.0f;
			newMissile.tag = "enemyMissile";
		}
	
	}

	void explode()
	{
		//spawn explosion object
		GameObject explosion = (GameObject)Instantiate(Resources.Load("explosion_object"));
		explosion.transform.position = this.transform.position;
		Destroy (this.transform.parent.transform.gameObject);
	}
}
