using UnityEngine;
using System.Collections;

public class DestroyObstacle : MonoBehaviour {
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.transform.CompareTag("obstacle"))//put tag on collider too, no parent
			Destroy(other.gameObject.transform.parent.gameObject);
	}
}
