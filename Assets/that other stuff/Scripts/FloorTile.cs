using UnityEngine;
using System.Collections;

public class FloorTile : MonoBehaviour {		

	public Vector3 MovementSpeed;
	
	void Start () {

	}
	
	void Update () {
		transform.position += MovementSpeed * Time.deltaTime;
	}

}
