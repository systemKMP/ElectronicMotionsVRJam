using UnityEngine;
using System.Collections;

public class TowerSpawner : MonoBehaviour {
	
	public float SpawnInterval;
	private float _timePassed = 0f;
	public GameObject SpawnObject;
	public float DestroyTimer;
	
	public float PositionOffset;
	public Transform MovementTarget;
	public float MovementSpeed;
	
	public float SoundDelay;
	
	void Start()
	{
	}
	
	void Update()
	{
		_timePassed += Time.deltaTime;
		if (_timePassed > SpawnInterval)
		{
			_timePassed -= SpawnInterval;
			Spawn();
		}
	}
	
	private void Spawn()
	{
		Vector3 pos= transform.position + Vector3.zero.AddRandomVector2(PositionOffset);
//		Vector3 pos = transform.position;
		GameObject obj = (GameObject)Instantiate(SpawnObject, pos, Quaternion.identity);
	}

}
