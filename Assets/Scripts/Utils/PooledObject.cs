﻿using UnityEngine;
using System.Collections;

public abstract class PooledObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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