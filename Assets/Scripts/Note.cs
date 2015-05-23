using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

    public Vector3 MovementSpeed;
    public ColliderType Target;

	void Update () {
        transform.position += MovementSpeed * Time.deltaTime;
	}
}
