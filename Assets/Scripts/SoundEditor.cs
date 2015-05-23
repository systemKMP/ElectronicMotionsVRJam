using UnityEngine;
using System.Collections;

public class SoundEditor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        bool left = true;
        foreach (var beat in SoundInfoContainer.Instance.Beats)
        {
            Vector2 pos;
            if (left)
            {
                beat.TargetType = ColliderType.LeftHand;
                pos.x = -0.5f;
            }
            else
            {
                beat.TargetType = ColliderType.RightHand;
                pos.x = 0.5f;
            }
            pos.y = Random.Range(-0.5f, 0.5f);
            beat.position = pos;
            left = !left;
        }

        
        var beats = SoundInfoContainer.Instance.Beats;

        for (int i = 0; i < beats.Count; i++)
        {

        }
	}

}
