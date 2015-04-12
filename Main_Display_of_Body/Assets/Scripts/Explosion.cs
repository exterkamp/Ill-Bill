using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float explodeWait;

	// Use this for initialization
	void Start () {
		StartCoroutine (Explode ());
	}
	
	IEnumerator Explode () {
		yield return new WaitForSeconds (explodeWait);
		Destroy (gameObject);
	}
}
