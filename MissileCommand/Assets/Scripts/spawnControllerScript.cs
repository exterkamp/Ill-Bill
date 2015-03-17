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
			Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPos.z = 0f;

			float distanceRight = Vector3.Distance (targetPos, targetPoints[0].transform.position);
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
			}
			GameObject newMissile = (GameObject) Instantiate(prefabs[Random.Range (0,prefabs.Length)], newPos, new Quaternion(0,0,0,0));
			missileScript m = newMissile.GetComponentInChildren<missileScript>();//.target = new Vector3(1,0,0);

			m.target = targetPos;
			m.speed = 0.1f;
			//print(m.target.x + "," + m.target.y);
			newMissile.tag = "friendlyMissile";
		}
		
		
		
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
			//spawn a missile
			GameObject newMissile = (GameObject) Instantiate(prefabs[Random.Range (0,prefabs.Length)], newPos, new Quaternion(0,0,0,0));
			missileScript m = newMissile.GetComponentInChildren<missileScript>();//.target = new Vector3(1,0,0);
			m.target = targetPoints[Random.Range (0,targetPoints.Length)].transform.position;
			m.speed = 0.025f;
			yield return new WaitForSeconds(Random.Range(0.5f,2f));
			newMissile.tag = "enemyMissile";
			
		}
	}

}
