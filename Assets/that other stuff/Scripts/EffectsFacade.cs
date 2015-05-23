﻿using UnityEngine;
using System.Collections;

public class EffectsFacade : MonoBehaviour {

	public bool randomRotation = true;
	public float rotationSpeed = 100;

	public void Particles() {
		_ps.Emit(200);
	}

	Rigidbody _rigidBody;
	ParticleSystem _ps;

	void Start () {
		_rigidBody = GetComponent<Rigidbody>();
		_ps = GetComponent<ParticleSystem>();

		if (randomRotation) {
			Vector3 v = new Vector3(rotationSpeed*Random.value, rotationSpeed*Random.value, rotationSpeed*Random.value);
			_rigidBody.angularVelocity = v;
		}
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Particles();
		}

	}
}