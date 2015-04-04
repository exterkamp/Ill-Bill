using UnityEngine;
using System.Collections;

public class markerScript : MonoBehaviour {

	private Camera cam;
	//private Vector3 velocity = Vector3.zero;
	//private float startTime;
	//private float journeyLength;
	//private float speed;// = 0.1f;
	//private Vector3 startMarker;
	//private Vector3 endMarker;

	public bool selected = false;
	public bool highlighted = false;

	public string minigame;


	// Use this for initialization
	void Start () {
		cam = Camera.main;
		//speed = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0) && !highlighted && selected) {
			transform.localScale  = new Vector3(1F, 1F, 1F);
			selected = false;
			cam.GetComponent<cameraLerper> ().goHome(0.3f);
			//StartCoroutine (ReturnCam (startMarker,endMarker,1f));
		}

		/*if (selected) {
			float distCovered = (Time.time - startTime);
			float fracJourney = distCovered / 1f;
			//float fracJourney = distCovered / journeyLength;
			cam.transform.position = Vector3.Lerp (startMarker, endMarker, fracJourney);
			
		}*/

	}

	/*IEnumerator ReturnCam(Vector3 source, float overTime)
	{
		Vector3 target = new Vector3 (0f,0f,-10f);
		float startTime = Time.time;
		while(Time.time < startTime + overTime && selected)
		{
			cam.transform.position = Vector3.Lerp(source, target, (Time.time - startTime)/overTime);
			yield return null;
		}
		if (selected) {
			cam.transform.position = target;
		} else {
			yield break;
		}
	}

	IEnumerator MoveObject(Vector3 source, Vector3 target, float overTime)
	{
		float startTime = Time.time;
		while(Time.time < startTime + overTime && selected)
		{
			cam.transform.position = Vector3.Lerp(source, target, (Time.time - startTime)/overTime);
			yield return null;
		}
		if (selected) {
			cam.transform.position = target;
		} else {
			yield break;
		}
	}*/
	
	
	
	void OnMouseEnter() {
		if (selected) {
			highlighted = true;
		}
	
	}

	void OnMouseDown() {
		//check if hit for a second time, if it is launch minigame!
		if (highlighted) {
			Application.LoadLevel (minigame);
		}
		selected = true;
		highlighted = true;
		transform.localScale  = new Vector3(1.25F, 1.25F, 1.25F);

		cam.GetComponent<cameraLerper> ().moveTo (transform.position, 0.5f);


		//StartCoroutine (MoveObject (startMarker,endMarker,1f));
	}

	void OnMouseExit(){
		highlighted = false;
	}

}
