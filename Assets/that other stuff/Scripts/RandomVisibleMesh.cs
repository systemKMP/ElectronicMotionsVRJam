using UnityEngine;
using System.Collections;

public class RandomVisibleMesh : MonoBehaviour {

	bool isOn = false;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
			
		bool wasOn = isOn;
		isOn = (Random.value < 0.08) ? !isOn : isOn;

		if (wasOn != isOn) {
			GetComponent<MeshRenderer>().enabled = isOn;
		}

	}
}
