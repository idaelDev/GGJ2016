using UnityEngine;
using System.Collections;

public class Spell : PooledObject {

    public ElementsNames type;
    
    public float spellSpeed;
    public bool moveright = true;

    private Vector3 movingDirection;

    protected void Start()
    {
        base.Start();
        movingDirection = Vector3.right;
        if(!moveright)
        {
            movingDirection *= -1;
        }

    }

	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        transform.position = transform.position + movingDirection * spellSpeed * Time.deltaTime;
    }

    public override void Init()
    {
        base.Init();
    }

    public override void Reset()
    {
        base.Reset();
    }

}
