using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public string tagName = "MusicLayer";

	void Start () {
		PlayAll();
	}

	public void PlayAll () {
		GameObject[] left = GameObject.FindGameObjectsWithTag(tagName);

		Debug.Log(left.Length);
		for (int i = 0, c = left.Length; i < c; i++) {
			AudioSource a = left[i].GetComponent<AudioSource>();
			a.Play();
//			a.volume = 0f;
			
//			if (i == 0)
//				a.volume = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
