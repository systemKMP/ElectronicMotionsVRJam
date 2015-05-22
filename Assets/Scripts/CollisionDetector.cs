using UnityEngine;
using System.Collections;

public enum ColliderType { LeftHand, RightHand, Head }

public class CollisionDetector : MonoBehaviour
{

    public ColliderType ColType;

    void OnTriggerEnter(Collider other)
    {
        if (ColType != ColliderType.Head)
        {
            EffectFactory.Instance.SpawnEffect(EffectType.Simple, other.gameObject.transform.position, 2.0f);
        }
        
    }

}
