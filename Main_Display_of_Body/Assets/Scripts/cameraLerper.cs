using UnityEngine;
using System.Collections;

public class cameraLerper : MonoBehaviour {

	private bool lerping = false;
	private bool target;
	private bool cachedLerp = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void moveTo(Vector3 target, float overTime){
		if (lerping) {
			cachedLerp = true;
		} else {
			lerping = true;
			cachedLerp = false;
		}
		StartCoroutine (goToPoint(target,overTime));
	}

	public void goHome(float overTime){
		Vector3 home = new Vector3 (0, 0, -10f);
		moveTo (home, overTime);
	}


	IEnumerator goToPoint(Vector3 point, float overTime)
	{
		point.z = -10f;
		//wait for cache to clear
		while (cachedLerp) {
			yield return null;
		}

		Vector3 target = point;
		Vector3 source = transform.position;
		float startTime = Time.time;

		while(Time.time < startTime + overTime && !cachedLerp)
		{
			transform.position = Vector3.Lerp(source, target, (Time.time - startTime)/overTime);
			yield return null;
		}

		//reset cache
		if (cachedLerp) {
			cachedLerp = false;
			lerping = false;
			yield break;
		} else {
			lerping = false;
			transform.position = point;
			yield break;
		}
	}


}
