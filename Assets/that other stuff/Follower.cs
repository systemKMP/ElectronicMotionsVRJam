using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {

    public Transform Target;
	
	// Update is called once per frame
	void Update () {
        transform.position = Target.position;
	}
}
