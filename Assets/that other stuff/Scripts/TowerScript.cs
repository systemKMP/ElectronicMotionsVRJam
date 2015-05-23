using UnityEngine;
using System.Collections;

public class TowerScript : MonoBehaviour {

	public GameObject tower = null;	
	public Vector3 MovementSpeed;
	
	void Start () {
		var tower = GetComponentInChildren<Transform>();
		if (tower == null) {
			Debug.LogWarning("nay found tower");
		}
		else {
			this.tower = tower.gameObject;
		}
	}
	
	void Update () {
		transform.position += MovementSpeed * Time.deltaTime;
	}

}
