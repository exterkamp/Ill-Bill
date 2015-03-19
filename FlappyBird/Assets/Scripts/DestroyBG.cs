using UnityEngine;
using System.Collections;

public class DestroyBG : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.transform.CompareTag("Background"))
			Destroy(other.gameObject);
		
	}
}
