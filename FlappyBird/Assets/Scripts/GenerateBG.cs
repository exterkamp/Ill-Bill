using UnityEngine;
using System.Collections;


public class GenerateBG : MonoBehaviour {
	public GameObject backgrounds;


	void Start() {
		StartCoroutine (CreateBackground ());
	}


	IEnumerator CreateBackground(){
		
		while(true){
			Instantiate(backgrounds);
			yield return new WaitForSeconds(9.9f);
		}

	}
}
