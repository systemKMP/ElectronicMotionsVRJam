using UnityEngine;
using System.Collections;

public class LPFilterExtension : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioLowPassFilter alpf = GetComponent<>(AudioLowPassFilter);
		public float cutoff = alpf.cutoffFrequency;
		cutoff = 22000;
	}
	
	// Update is called once per frame
	void Update () {
		cutoff = 
	}
}
