using UnityEngine;
using System.Collections;

public enum ColliderType { LeftHand, RightHand, Head }

public class CollisionDetector : MonoBehaviour
{

    public ColliderType ColType;

    bool TriggerDownLastFrame = false;
    bool TriggerPressedLastFrame = false;
    private int ControllerIndex;

    void Awake()
    {
        ControllerIndex = 0;
        if (ColType == ColliderType.RightHand)
        {
            ControllerIndex = 1;
        }
    }

    //void Update()
    //{
    //    if (ColType != ColliderType.Head){
    //        if (SixenseInput.Controllers[ControllerIndex].Trigger > 0.2f)
    //        {
    //            if (!TriggerDownLastFrame)
    //            {
    //                TriggerPressedLastFrame = true;

    //            }
    //            else
    //            {
    //                TriggerPressedLastFrame = false;
    //            }
    //            TriggerDownLastFrame = true;
    //        }
    //        else
    //        {
    //            TriggerDownLastFrame = false;
    //            TriggerPressedLastFrame = false;
    //        }
    //    }
    //}

    void OnTriggerEnter(Collider other)
    {
        var note = other.GetComponent<Note>();
        if (note.Target == ColType)
        {
            note.Hit();
            SpawnEffect(other.transform.position);
        }

    }

    //void FixedUpdate()
    //{
    //    Debug.Log(TriggerPressedLastFrame);
    //}

    private void SpawnEffect(Vector3 pos)
    {
        if (ColType != ColliderType.Head)
        {
            EffectFactory.Instance.SpawnEffect(EffectType.Simple, pos, 2.0f);
           
        }
    }

}
