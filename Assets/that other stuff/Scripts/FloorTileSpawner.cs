using UnityEngine;
using System.Collections;

public class FloorTileSpawner : MonoBehaviour {

	public GameObject SpawnObject;

	public Vector3 startVel;

	public float SpawnInterval;
	private float _timePassed = 0f;


	// Use this for initialization
	void Start () {
		Spawn();
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
		Vector3 pos = transform.position;
		
		GameObject obj = (GameObject)Instantiate(SpawnObject, pos, Quaternion.identity);
		
		FloorTile f = obj.GetComponent<FloorTile>();
		f.MovementSpeed = startVel;

	}
}
