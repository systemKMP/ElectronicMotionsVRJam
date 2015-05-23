using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

    public Vector3 MovementSpeed;
    public ColliderType Target;

    public bool CombineWithNext;
    private Note _nextNote;
    public Note NextNote{
        get
        {
            return _nextNote;
        }
        set
        {
            for (int i = 0; i < 8; i++)
            {
                Instantiate(value, transform.position + (value.transform.position - transform.position) / 8.0f * i, Quaternion.identity);
            }
            _nextNote = value;
        }
    
    }

	void Update () {
        transform.position += MovementSpeed * Time.deltaTime;



	}

    public void Hit()
    {
        if (!CombineWithNext)
        {
            Destroy(this.gameObject);
        }
    }
}
