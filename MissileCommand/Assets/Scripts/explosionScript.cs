using UnityEngine;
using System.Collections;

public class explosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine( die() );
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collidee)
	{
		//destroy a missile
		if (!collidee.gameObject.CompareTag ("explosion")) {
			if (collidee.gameObject.transform.parent.gameObject.CompareTag ("enemyMissile")) {
				Destroy (collidee.gameObject.transform.parent.gameObject);
			}
		}
	}

	IEnumerator die()
	{
		while (true) {

			//hold
			yield return new WaitForSeconds(0.2f);
			//die
			Destroy(this.gameObject);
			
		}
	}

}
