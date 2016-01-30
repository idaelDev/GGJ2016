using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

    public int poolSize = 5;
    public PooledObject objectToPool;

    private List<PooledObject> pool;

	// Use this for initialization
	protected void Start () {
        InstantiatePool();
	}

    void InstantiatePool()
    {
        pool = new List<PooledObject>(poolSize);
        for (int i = 0; i < poolSize; i++)
        {
            pool.Add(InstantiatePoolObject());
        }
    }

    PooledObject InstantiatePoolObject()
    {
        PooledObject obj = Instantiate(objectToPool, transform.position, transform.rotation) as PooledObject;
        obj.gameObject.SetActive(false);
        obj.OriginPool = this;
        pool.Add(obj);
        return obj;
    }
	
    public PooledObject GetObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if(!pool[i].isActiveAndEnabled)
            {
                pool[i].Init();
                return pool[i];
            }
        }
        PooledObject obj = InstantiatePoolObject();
        obj.Init();
        return obj;
    }
	
    public void HideObject(PooledObject obj)
    {
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.Reset();
        obj.gameObject.SetActive(false);
    }
}
