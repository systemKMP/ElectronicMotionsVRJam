using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour {

    public float SpawnInterval;
    private float _timePassed;
    public GameObject SpawnObject;
    public float DestroyTimer;

    public float PositionOffset;
    public Transform MovementTarget;
    public float MovementSpeed;

    public float SoundDelay;

    void Start()
    {
        _timePassed = 0.0f;
    }

    void Update()
    {
        _timePassed += Time.deltaTime;
        if (_timePassed > SpawnInterval)
        {
            _timePassed -= SpawnInterval;
            SpawnNewNote();
        }
    }

    private void SpawnNewNote()
    {
        GameObject obj = (GameObject)Instantiate(SpawnObject, transform.position + Vector3.zero.AddRandomVector(PositionOffset), Quaternion.identity);

		Note note = obj.GetComponent<Note>();
		if (note != null) {
	        note.MovementSpeed = (MovementTarget.position - transform.position).normalized * MovementSpeed;
	        Destroy(note.gameObject, DestroyTimer);
		}
        
    }

}
