using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

    public Vector3 MovementSpeed;

	void Update () {
        transform.position += MovementSpeed * Time.deltaTime;
	}
}
