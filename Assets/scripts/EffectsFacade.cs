using UnityEngine;
using System.Collections;

public class EffectsFacade : MonoBehaviour {

	public bool randomRotation = true;
	public float rotationSpeed = 100;

	public void Particles() {
		
	}

	Rigidbody _rigidBody;

	void Start () {
		_rigidBody = GetComponent<Rigidbody>();

		if (randomRotation) {
			Vector3 v = new Vector3(rotationSpeed*Random.value, rotationSpeed*Random.value, rotationSpeed*Random.value);
			_rigidBody.angularVelocity = v;
		}
	}
	
	void Update () {
	
	}
}
