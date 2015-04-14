using UnityEngine;
using System.Collections;

public class DestroyObstacle : MonoBehaviour {
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject != null && other.gameObject.transform  != null && other.gameObject.transform.parent != null && other.gameObject.transform.parent.gameObject != null)
		Destroy(other.gameObject.transform.parent.gameObject);
	}
}
