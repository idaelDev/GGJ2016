using UnityEngine;
using System.Collections;

public abstract class PooledObject : MonoBehaviour {

    private ObjectPool originPool;

    public ObjectPool OriginPool
    {
        get { return originPool; }
        set { originPool = value; }
    }

	// Use this for initialization
	protected void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public virtual void Init()
    {
        gameObject.SetActive(true);
    }
    public virtual void Reset()
    {
        gameObject.SetActive(false);
    }

}