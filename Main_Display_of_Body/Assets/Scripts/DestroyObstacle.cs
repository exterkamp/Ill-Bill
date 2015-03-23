using UnityEngine;
using System.Collections;

public class DestroyObstacle : MonoBehaviour {
	
	void OnTriggerExit2D(Collider2D other)
	{
		Destroy(other.gameObject.transform.parent.gameObject);
	}
}
