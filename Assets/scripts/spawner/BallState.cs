using UnityEngine;
using System.Collections;

public class BallState : MonoBehaviour {
	
	public bool hasPlayedFartSount = false;
	public bool hasDealtDamage = false;
	public float hitDist = -1f;
	
	public bool inHitZone = false;
	
	public Vector3 velocity;
}
