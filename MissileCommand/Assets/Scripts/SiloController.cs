using UnityEngine;
using System.Collections;

public class SiloController : MonoBehaviour {

	public int ammunition;
	public siloState state;
	//private bool canFire;
	private GameObject magazine;
	private ArrayList magazineObjects = new ArrayList();
	public Sprite ruined;


	public enum siloState {ready,reloading,ruins,roundsComplete};

	// Use this for initialization
	void Start () {
		//ammunition = 10;
		state = siloState.ready;
		//canFire = true;
		magazine = gameObject.transform.parent.FindChild("magazine").gameObject;
		fillMagazine ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ammunition == 0 && state != siloState.ruins) {
			state = siloState.roundsComplete;
		}

	}

	private void fillMagazine(){
		for (int i = 0; i < ammunition; i++) {
			GameObject missile = (GameObject)Instantiate(Resources.Load("magazine_missile"));
			missile.transform.position = new Vector3(magazine.transform.position.x + i * 0.1f,magazine.transform.position.y,magazine.transform.position.z);
			//missile.transform.position.x += i * 0.1f;
			magazineObjects.Add(missile);
		}
	}

	public int getAmmo(){
		return ammunition;
	}

	public void decAmmo(){
		ammunition -= 1;
		int index = magazineObjects.Count-1;
		GameObject g = (GameObject)magazineObjects[index];
		magazineObjects.RemoveAt(index);
		Destroy (g);
		//print (ammunition);
	}

	public bool canSiloFire(){
		if (state == siloState.ready)
			return true;
		else
			return false;
		//return canFire;
	}

	public void die(){
		state = siloState.ruins;
		GetComponent<SpriteRenderer> ().sprite = ruined;
		int ammoMax = ammunition;
		for (int i = 0; i < ammoMax; i++) {
			decAmmo();
		}
	}
}
