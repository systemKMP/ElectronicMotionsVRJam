using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoteSpawner : MonoBehaviour
{

    public float SpawnInterval;
    private float _timePassed;
    public GameObject SpawnObject;
    public float DestroyTimer;

    public float PositionOffset;
    public Transform MovementTarget;
    public float MovementSpeed;

    public float SoundDelay;

    private int currentIndex = 0;

    public List<AudioSource> tracks;
    private bool musicStarted = false;
    private bool gameStarted = false;

    void Start()
    {
        _timePassed = 0.0f;
        SoundDelay = (transform.position - MovementTarget.position).magnitude / MovementSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
        }

        if (gameStarted)
        {
            _timePassed += Time.deltaTime;
            if (SoundInfoContainer.Instance.Beats.Count > currentIndex && SoundInfoContainer.Instance.Beats[currentIndex].Time <= _timePassed)
            {

                SpawnNewNote(SoundInfoContainer.Instance.Beats[currentIndex]);
                currentIndex++;
            }
            if (_timePassed > SoundDelay && !musicStarted)
            {
                musicStarted = true;
                StartMusic();
            }
        }

    }

    private void SpawnNewNote(Beat b)
    {
        var obj = Instantiate(SpawnObject, transform.position + new Vector3(b.position.x, b.position.y, 0.0f), Quaternion.identity) as Note;
        obj.MovementSpeed = (MovementTarget.position - transform.position).normalized * MovementSpeed;
        obj.Target = b.TargetType;
        Destroy(obj.gameObject, DestroyTimer);

    }

    private void StartMusic()
    {
        foreach (var track in tracks)
        {
            track.Play();
        }
    }

}
