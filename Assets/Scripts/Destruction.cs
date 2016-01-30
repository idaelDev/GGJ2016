using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<PooledObject>().OriginPool.HideObject(other.gameObject.GetComponent<PooledObject>());
    }
}
