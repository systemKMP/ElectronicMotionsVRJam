using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpMover : MonoBehaviour {

    public float Speed;
    public Text txt;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 1.2f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.rotation * Vector3.up * Speed * Time.deltaTime, Space.Self);
        Color c = txt.color;
        c.a = Mathf.MoveTowards(c.a, 0.0f, Time.deltaTime);
        txt.color = c;
    }
}
