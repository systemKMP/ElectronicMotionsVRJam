using UnityEngine;
using System.Collections;

public class TowerScript : MonoBehaviour {

	public bool isExpanded = false;
	public GameObject tower = null;	
	public KeyCode keyActivate = KeyCode.Alpha1;
	
	void Start () {
		var tower = GetComponentInChildren<Transform>();
		if (tower == null) {
			Debug.LogWarning("nay found tower");
		}
		else {
			this.tower = tower.gameObject;
		}

		GetComponent<Animator>().Play("idle");

	}
	
	void Update () {
		if (Input.GetKeyDown(keyActivate)) {
			Expand();	
		}
	}

	public void Expand() {
//		GetComponent<Animator>().SetTrigger("Start");		

		GetComponent<Animator>().Play("scale up");
	}
}
