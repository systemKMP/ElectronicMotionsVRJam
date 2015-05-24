using UnityEngine;
using System.Collections;
using System;

public class Note : MonoBehaviour
{

    public Vector3 MovementSpeed;
    public ColliderType Target;

    public bool CombineWithNext;
    private Note _nextNote;

    public float TargetTime;
    public bool CountTime = false;
    public bool MinPart;

    public Guid guid;
    public bool TakeID;

    void Awake()
    {
        
        TakeID = false;
    }

    public Note NextNote
    {
        get
        {
            return _nextNote;
        }
        set
        {
            guid = Guid.NewGuid();
            for (int i = 1; i < 8; i++)
            {
                var note = Instantiate(value, transform.position + (value.transform.position - transform.position) / 8.0f * i, Quaternion.identity) as Note;
                note.MinPart = true;
                note.TakeID = true;
                note.guid = guid;
            }
            TakeID = true;
            value.TakeID = true;
            value.guid = guid;
            _nextNote = value;
        }

    }

    void Update()
    {
        transform.position += MovementSpeed * Time.deltaTime;
        if (ScoreController.Instance.TimePassed - TargetTime > 0.32f)
        {
            ScoreController.Instance.ReportMiss();
            Destroy(this.gameObject);

        }
    }

    public void Hit()
    {
        if (TakeID)
        {
            if (ComboObserver.Instance.SubmitID(guid))
            {
                EffectFactory.Instance.SpawnEffect(EffectType.Super, transform.position, 2.0f);
                ScoreController.Instance.ReportCombo();
            }
        }
        if (!MinPart)
        {
            SoundPlayer.Instance.PlayRandomClip();
            ScoreController.Instance.ReportScore(TargetTime);
        }
        else
        {
            ScoreController.Instance.ReportMin(TargetTime);
        }
        Destroy(this.gameObject);
    }
}
