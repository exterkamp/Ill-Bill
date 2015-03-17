using UnityEngine;
using System.Collections;

public class DestroyBG : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other)
	{
		
		Destroy(other.gameObject);
		
	}
}
