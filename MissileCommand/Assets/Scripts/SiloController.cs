using UnityEngine;
using System.Collections;

public class SiloController : MonoBehaviour {

	private int ammunition;
	private bool canFire;
	private GameObject magazine;
	private ArrayList magazineObjects = new ArrayList();

	// Use this for initialization
	void Start () {
		ammunition = 20;
		canFire = true;
		magazine = gameObject.transform.parent.FindChild("magazine").gameObject;
		fillMagazine ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ammunition == 0) {
			canFire = false;
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
		return canFire;
	}
}
