using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Collections;

public class GenerateObst : MonoBehaviour {
	
	public GameObject[] rocks;
	public static float startWait;
	public static float spawnWait;
	
	
	
	// Use this for initialization
	void Start() {
		
		
		StartCoroutine (CreateObstacle ());
	}
	
	IEnumerator CreateObstacle(){
		yield return new WaitForSeconds(startWait);
		
		while(true){
			
			Instantiate(rocks[Random.Range (0,rocks.Length)]);
			
			yield return new WaitForSeconds(spawnWait+(float)(Random.Range (-1,1)*.25));
		}
	}
	
}