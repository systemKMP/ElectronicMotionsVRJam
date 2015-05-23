using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoteSpawner : MonoBehaviour
{

    public float SpawnInterval;
    private float _timePassed;
    public Note SpawnObject;
    public float DestroyTimer;

    public float PositionOffset;
    public Transform MovementTarget;
    public float MovementSpeed;

    public float SoundDelay;

    private int currentIndex = 0;

    public List<AudioSource> tracks;
    private bool musicStarted = false;
    private bool gameStarted = false;

    private Note PreviousLNote;
    private Note PreviousRNote;

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
        obj.TargetTime = b.Time;
        obj.MinPart = false;
        if (b.CombineWithNext)
        {
            if (obj.Target == ColliderType.LeftHand)
            {
                PreviousLNote = obj;
            }
            else if (obj.Target == ColliderType.RightHand)
            {
                PreviousRNote = obj;
            }
        }
        else if (obj.Target == ColliderType.LeftHand && PreviousLNote != null)
        {
            PreviousLNote.NextNote = obj;
            if (obj.CombineWithNext)
            {
                PreviousLNote = obj;
            }
            else
            {
                PreviousLNote = null;
            }
        }
        else if (obj.Target == ColliderType.RightHand && PreviousRNote != null)
        {
            PreviousRNote.NextNote = obj;
            if (obj.CombineWithNext)
            {
                PreviousRNote = obj;
            }
            else
            {
                PreviousRNote = null;
            }
        }

        Destroy(obj.gameObject, DestroyTimer);
    }

    private void StartMusic()
    {
        ScoreController.Instance.CalculateTime = true;
        foreach (var track in tracks)
        {
            track.Play();
        }
    }

}
