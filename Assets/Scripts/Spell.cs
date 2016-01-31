using UnityEngine;
using System.Collections;

public class Spell : PooledObject {

    public ElementsNames type;
    
    public float spellSpeed;
    public bool moveright = true;

    public bool moving;

    private Vector3 movingDirection;
    private Animator anim;

    protected void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        movingDirection = Vector3.right;
        if(!moveright)
        {
            movingDirection *= -1;
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

	// Update is called once per frame
	void Update () {

        if (moving)
        {
            Move();
        }
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
        moving = false;
    }

    public void StartMoving()
    {
        moving = true;
        Debug.Log(moving);
    }

    public void Destruction()
    {
        OriginPool.HideObject(this);
    }
    
    public void AnimateHit()
    {
        moving = false;
        anim.SetTrigger("Hit");
    }
}
