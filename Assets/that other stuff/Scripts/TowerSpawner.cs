using UnityEngine;
using System.Collections;

public class TowerSpawner : MonoBehaviour {

	public bool random2d = true;

	public float SpawnInterval;
	private float _timePassed = 0f;

	public GameObject SpawnObject;

	public float DestroyTimer;
	
	public float PositionOffset;

	public Transform MovementTarget;
	public float MovementSpeed;
	
	public float SoundDelay;

	// 14.1048

	void Start()
	{
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

		TowerScript towerScript = obj.GetComponent<TowerScript>();
		towerScript.MovementSpeed = towerScript.MovementSpeed * MovementSpeed;


	}

}
