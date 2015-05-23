using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour
{

    public Vector3 MovementSpeed;
    public ColliderType Target;

    public bool CombineWithNext;
    private Note _nextNote;

    public float TargetTime;
    public bool CountTime = false;
    public bool MinPart;

    public Note NextNote
    {
        get
        {
            return _nextNote;
        }
        set
        {
            for (int i = 0; i < 8; i++)
            {
                var note = Instantiate(value, transform.position + (value.transform.position - transform.position) / 8.0f * i, Quaternion.identity) as Note;
                note.MinPart = true;
            }
            _nextNote = value;
        }

    }

    void Update()
    {
        transform.position += MovementSpeed * Time.deltaTime;
        if (ScoreController.Instance.TimePassed - TargetTime > 0.32f)
        {
            ScoreController.Instance.ReportMiss();

        }
    }

    public void Hit()
    {
        if (!MinPart)
        {
            SoundPlayer.Instance.PlayRandomClip();
            ScoreController.Instance.ReportScore(TargetTime);
        }
        else
        {
            ScoreController.Instance.ReportMin(TargetTime);

        }
        if (!CombineWithNext)
        {
            Destroy(this.gameObject);
        }
    }
}
