using UnityEngine;
using System.Collections;

public class spawnControllerScript : MonoBehaviour {
	
	public GameObject[] prefabs;
	public GameObject[] spawnPoints;
	//public GameObject[] targetPoints;
	public GameObject[] siloPoints;

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
			GameObject silo = findSiloFire(targetPos);
			//CHECK NULL
			if (silo != null){
				Vector3 newPos = silo.transform.position;
				//dec silo
				silo.GetComponentInChildren<SiloController>().decAmmo();

				GameObject newMissile = (GameObject) Instantiate(prefabs[Random.Range (0,prefabs.Length)], newPos, new Quaternion(0,0,0,0));
				missileScript m = newMissile.GetComponentInChildren<missileScript>();//.target = new Vector3(1,0,0);

				m.target = targetPos;
				m.speed = 0.1f;
				m.clusterChance = -1.0f;
				//print(m.target.x + "," + m.target.y);
				newMissile.tag = "friendlyMissile";
			}

		}
		
		
		
	}

	GameObject findSiloFire(Vector3 targetPos){
		float curDistance = 1000f;
		GameObject curSilo = null;
		//read ammo cap
		foreach (GameObject g in siloPoints){
			SiloController s = g.GetComponentInChildren<SiloController>();
			if (s.canSiloFire() && (Vector3.Distance (targetPos, g.transform.position)) < curDistance){
				curSilo = g;
				curDistance = Vector3.Distance (targetPos, g.transform.position);
			}

		}
		return curSilo;
	}

	public GameObject findSiloTarget(){
		//assume there is a target left
		bool canTarget = false;

		foreach (GameObject g in siloPoints) {
			if (g.transform.FindChild("city").GetComponent<SiloController>().state != SiloController.siloState.ruins){
				canTarget = true;
			}
		}

		GameObject targetSilo = null;

		if (canTarget) {
			while (targetSilo == null){
				GameObject g = siloPoints[Random.Range (0,siloPoints.Length)];
				if (g.transform.FindChild("city").GetComponent<SiloController>().state != SiloController.siloState.ruins){
					targetSilo = g;
				}
			}
		}

		return targetSilo;
		//siloPoints[Random.Range (0,siloPoints.Length)].transform.position;
		
		
	}
	
	//fixed update
	void FixedUpdate(){

	}

	IEnumerator missileLaunch()
	{
		while (true) {
			//new Pos
			GameObject target = findSiloTarget();

			if (target != null)
			{
				Vector3 newPos = spawnPoints [Random.Range (0,spawnPoints.Length)].transform.position;
				newPos.x = newPos.x + Random.Range(0f,2f) - Random.Range(-2f,0f);
				//print (newPos.x);
				//spawn a missile
				GameObject newMissile = (GameObject) Instantiate(prefabs[Random.Range (0,prefabs.Length)], newPos, new Quaternion(0,0,0,0));
				missileScript m = newMissile.GetComponentInChildren<missileScript>();//.target = new Vector3(1,0,0);

				m.target = target.transform.position;


				m.speed = 0.025f;
				m.clusterChance = 0.001f;
				newMissile.tag = "enemyMissile";
			}
			yield return new WaitForSeconds(Random.Range(1f,3f));

			
		}
	}

	public void blowUpTarget(GameObject targetToBlowUp){
		//targetToBlowUp
	}

}
