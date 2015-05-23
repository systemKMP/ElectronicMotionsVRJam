using UnityEngine;
using System.Collections;

public class EffectsFacade : MonoBehaviour {

	public bool randomRotation = true;
	private float rotationSpeed = 1.2f;

	public void Particles() {
		_ps.Emit(200);
	}

    private Vector3 angularVel;

    //public Rigidbody rigidBody;
	ParticleSystem _ps;

	void Start () {
		_ps = GetComponentInParent<ParticleSystem>();

		if (randomRotation) {
            angularVel = (new Vector3(rotationSpeed * Random.value, rotationSpeed * Random.value, rotationSpeed * Random.value) - Vector3.one/2.0f) * 100.0f;
            //rigidBody.angularVelocity = v;
		}
	}
	
	void Update () {
        transform.Rotate(angularVel * Time.deltaTime);
        //if (Input.GetKeyDown(KeyCode.Space)) {
        //    Particles();
        //}

	}
}
