using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayOnBeat : MonoBehaviour {
	
	public ParticleSystem ps;
	public static PlayOnBeat Instance = null;
	
	public AudioSource StateStart;
	public AudioSource StateDrums;
	public AudioSource StateBass;
	public Material pulseMaterial;
	public AudioClip prepareSound;
	public AudioClip startRaceSound;
	public AudioClip stopRaceSound;
	
	public static float pulse = 0;
	public static float pulseA = 0;
	public static float pulseB = 0;
	private float beatStartTime = 0;
	
	private int BPM = 120;
	
	public static float beatTime = 0;
	public static bool playBeat = false;
	public static int beat;
	
	[Range (0, 1)]
	public float progression = 0;
	public static float goalProgression { get { return Instance.progression; } set { Instance.progression = value; } }
	
	private Color skyColor;
	
	private float oneOffSoundsVolume = 0.5f;
	
	void Awake ()
	{
		Instance = this;
	}
	
	void Start () {
	}
	
	void Update () {
		pulse = Mathf.Lerp (pulse, 0, Time.deltaTime * 20);
		pulseA = Mathf.Lerp (pulseA, 0, Time.deltaTime * 20);
		pulseB = Mathf.Lerp (pulseB, 0, Time.deltaTime * 20);
		
		// Pulse material
		pulseMaterial.SetFloat ("_Extrude", Mathf.Lerp (pulse, pulseA, 0.5f) * 0.5f);
	}
	
	public void Beat () {
		pulse = 1;
		if (beat % 2 == 1) {
			pulseA = 1;
			//SetSkyColor (Color.Lerp (skyColor, Color.black, 0.3f));
		}
		else {
			pulseB = 1;
			//SetSkyColor (skyColor);
		}
	}

}
