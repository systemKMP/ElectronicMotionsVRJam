using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour {

    public float SpawnInterval;
    private float _timePassed;
    public Note SpawnObject;
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
        var obj = Instantiate(SpawnObject, transform.position + Vector3.zero.AddRandomVector(PositionOffset), Quaternion.identity) as Note;
        obj.MovementSpeed = (MovementTarget.position - transform.position).normalized * MovementSpeed;
        Destroy(obj.gameObject, DestroyTimer);
        
    }

}
