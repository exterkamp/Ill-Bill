using UnityEngine;
using System.Collections;

public class spawnControllerScript : MonoBehaviour {
	
	public GameObject[] prefabs;
	public GameObject[] spawnPoints;
	public GameObject[] targetPoints;


	// Use this for initialization
	void Start () {
		StartCoroutine (missileLaunch());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//get silo
			Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPos.z = 0f;
			GameObject silo = findSilo(targetPos);
			//CHECK NULL
			if (silo != null){
				Vector3 newPos = silo.transform.position;
				//dec silo
				silo.GetComponentInChildren<SiloController>().decAmmo();

				GameObject newMissile = (GameObject) Instantiate(prefabs[Random.Range (0,prefabs.Length)], newPos, new Quaternion(0,0,0,0));
				missileScript m = newMissile.GetComponentInChildren<missileScript>();//.target = new Vector3(1,0,0);

				m.target = targetPos;
				m.speed = 0.1f;
				//print(m.target.x + "," + m.target.y);
				newMissile.tag = "friendlyMissile";
			}

		}
		
		
		
	}

	GameObject findSilo(Vector3 targetPos){
		float curDistance = 1000f;
		GameObject curSilo = null;
		//read ammo cap
		foreach (GameObject g in targetPoints){
			SiloController s = g.GetComponentInChildren<SiloController>();
			if (s.canSiloFire() && (Vector3.Distance (targetPos, g.transform.position)) < curDistance){
				curSilo = g;
				curDistance = Vector3.Distance (targetPos, g.transform.position);
			}

		}
		
		return curSilo;



		/*float distanceRight = Vector3.Distance (targetPos, targetPoints[0].transform.position);
		float distanceMid = Vector3.Distance (targetPos, targetPoints[1].transform.position);
		float distanceLeft = Vector3.Distance (targetPos, targetPoints[2].transform.position);
		//
		Vector3 newPos = targetPoints [1].transform.position;
		if (distanceRight < distanceMid)
		{
			newPos = targetPoints [0].transform.position;
		}
		if (distanceLeft < distanceMid){
			newPos = targetPoints [2].transform.position;
		}*/

	}
	
	//fixed update
	void FixedUpdate(){

		//new Pos
		//Vector3 newPos = spawnPoints [Random.Range (0,spawnPoints.Length)].transform.position;
		//spawn a missile
		//GameObject newMissile = (GameObject) Instantiate(prefabs[Random.Range (0,prefabs.Length)], newPos, new Quaternion(0,0,0,0));
		//missileScript m = newMissile.GetComponentInChildren<missileScript>();//.target = new Vector3(1,0,0);
		//m.target = targetPoints[Random.Range (0,targetPoints.Length)].transform.position;
		//var ScriptName = newMissile.GetComponent(missileScript);
		// use the targetScript reference to access the variable Clips:
		//scriptName.target += 10;
	}

	IEnumerator missileLaunch()
	{
		while (true) {
			//new Pos
			Vector3 newPos = spawnPoints [Random.Range (0,spawnPoints.Length)].transform.position;
			newPos.x = newPos.x + Random.Range(0f,2f) - Random.Range(-2f,0f);
			//print (newPos.x);
			//spawn a missile
			GameObject newMissile = (GameObject) Instantiate(prefabs[Random.Range (0,prefabs.Length)], newPos, new Quaternion(0,0,0,0));
			missileScript m = newMissile.GetComponentInChildren<missileScript>();//.target = new Vector3(1,0,0);
			m.target = targetPoints[Random.Range (0,targetPoints.Length)].transform.position;
			m.speed = 0.025f;
			newMissile.tag = "enemyMissile";
			yield return new WaitForSeconds(Random.Range(0.5f,2f));

			
		}
	}

}
