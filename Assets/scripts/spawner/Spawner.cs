using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
	
	public float minHitDist = 0.05f;
	public float maxHitDist = 0.3f; // nice: 0.275
	
	public float speed = -5f;
	public KeyCode hitKeyCode = KeyCode.Space;
	public Transform hitPoint;
	public float startDelaySeconds = 2f;
	
	public GameObject ballPrefab;
	
	public bool debug = false;
	public float debugMargin = 6f;
	public int numDebugBalls = 6;
	
	List<GameObject> balls;
	
	void Start () {
		balls = new List<GameObject>();
		
		if (debug)
			layoutDebugBalls ();
	}
	
	public void layoutDebugBalls() {
		if (balls.Count > 0) {
			for (var i = 0; i < balls.Count; i++) {
				Destroy(balls[i]);
			}			
			balls.Clear ();			
		}

		List<float> levelDataPoints = new List<float> ();		
		
		// data
		for (var i = 0; i < numDebugBalls; i++) {
			levelDataPoints.Add(i * debugMargin);
		}
		
		// render
		float offset = Mathf.Abs(speed) * startDelaySeconds; // 2 sec before they appear
		for (var i = 0; i < levelDataPoints.Count; i++) {
			GameObject go = (GameObject) Instantiate(ballPrefab);
			//			go.transform.parent = this.gameObject.transform;
			//			float offsetY = offset + levelDataPoints[i];
			float offsetY = offset + levelDataPoints[i];
			
			go.transform.position += hitPoint.transform.position + (hitPoint.transform.up * offsetY);
			go.transform.rotation = hitPoint.transform.rotation;
			//			go.transform.rotation = hitPoint
			
			Vector3 newVel = go.transform.position - hitPoint.position;
			newVel = newVel.normalized * speed;
			go.GetComponent<BallState>().velocity = newVel;
			
			balls.Add(go);
		}
	}
	
	void MoveBalls() {
		for (var i = 0; i < balls.Count; i++) {
			GameObject go = balls[i];
			
			//go.transform.position = go.transform.position + new Vector3(0, speed * Time.deltaTime, 0);
			Vector3 delta = go.GetComponent<BallState>().velocity * Time.deltaTime;
			go.transform.position += delta;
		}
	}
	
	//	bool isCloseEnough (Vector3 pos1) {
	//
	//	}
	
	void removeIfOutOfCamera() {
		for (var i = balls.Count; --i >= 0;) {
			GameObject go = balls[i];
			if (go.transform.position.y < -14) {
				Destroy(balls[i]);
				balls.RemoveAt(i);
				//				Debug.Log("removed");
			}
		}
	}
	
	void markClosesBall() {
		if (balls.Count > 0) {
			GameObject closestGO = balls[0];
			float closestDist = -1f;
			for (var i = 1; i < balls.Count; i++) {
				GameObject subject = balls[i];
				float newDist = Vector3.Distance(subject.transform.position, closestGO.transform.position);
				bool isAHit = (newDist < closestDist);
				if (isAHit) {
					closestGO = subject;
					closestDist = newDist;
				}
			}
			
			closestGO.GetComponent<BallState>().hitDist = closestDist;
		}
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			if (debug) {
				layoutDebugBalls();
				Debug.Log(balls.Count);
			}
		}
		
		MoveBalls ();
		
		
		// play fart sound once
		for (var i = balls.Count; --i >= 0;) {
			GameObject subject = balls[i];
			bool inHitZone = (Vector3.Distance(hitPoint.position, subject.transform.position) < maxHitDist);
			if (inHitZone){
				subject.GetComponent<BallState>().inHitZone = true;
			}
			if (subject.GetComponent<BallState>().hasPlayedFartSount == false && inHitZone) {
				subject.GetComponent<BallState>().hasPlayedFartSount = true;
			}
		}
		
		// hit test and remove and play sound
		
		if (Input.GetKeyDown(hitKeyCode)) {
			float smallestDist = -1f;
			float score = -1f;
			GameObject objectThatWasHit = null;
			
			for (var i = balls.Count; --i >= 0;) {
				GameObject subject = balls[i];
				float newDist = Vector3.Distance(subject.transform.position, hitPoint.position);
				if (smallestDist == -1f || newDist < smallestDist) smallestDist = newDist;
				bool isAHit = (newDist <= maxHitDist);
				if (isAHit) {
					score = (newDist < minHitDist) ? 1f : (newDist-minHitDist)/(maxHitDist-minHitDist);
					objectThatWasHit = subject;
					balls.RemoveAt(i);
					//					var wasRemoved = ballsGO.Remove(subject);
					//					Debug.Log("was removed " + wasRemoved);
					//					Destroy(subject);
					break;
				}
			}
			
			if (score != -1f) {
				//				Debug.Log("OnScore");
				SendMessage("OnScore",score);
			}
			if (objectThatWasHit != null) {
				//				Debug.Log("OnHit");
				SendMessage("OnHit", objectThatWasHit);
			}
			if (smallestDist != -1f) {
				//				Debug.Log("OnClosestObject");
				SendMessage("OnClosestObject", smallestDist);
			}
		}
		
		// deal damage if ball came out of hit target
		for (var i = balls.Count; --i >= 0;) {
			GameObject subject = balls[i];
			float newDist = Vector3.Distance(subject.transform.position, hitPoint.position);
			bool isOutOfHitZone = (newDist > maxHitDist);
			if (isOutOfHitZone) {
				if (subject.GetComponent<BallState>().inHitZone) {
					subject.GetComponent<BallState>().inHitZone = false;
					SendMessage("OnMissed", subject);
				}
				if (subject.GetComponent<BallState>().hasPlayedFartSount && !subject.GetComponent<BallState>().hasDealtDamage) {
					subject.GetComponent<BallState>().hasDealtDamage = true;				
				}
			}
		}
		
		removeIfOutOfCamera ();
	}
}
