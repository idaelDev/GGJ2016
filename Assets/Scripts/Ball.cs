using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float initialSpeed = 1f;
    public float maxSpeedAugmentationMult = 10f;
    public Transform rightPlayerTransform;
    public Transform leftplayerTransform;

    private ElementsNames element;
    private float speed;
    private bool goRight = true;
    private PlayerPosition currentPlayerTarget = PlayerPosition.RIGHT;
    private float distanceBetweenPlayers;
    private Vector3 moveDirection = Vector3.right;

    void Start()
    {
        speed = initialSpeed;
        distanceBetweenPlayers = Vector3.Distance(rightPlayerTransform.position, leftplayerTransform.position);
    }

    void Update()
    {
        Vector3 move = moveDirection * speed * Time.deltaTime;
        if(!goRight)
        {
            move *= -1;
        }
        transform.position = transform.position + move;
    }

    public bool GoRight
    {
        get { return goRight; }
        set { goRight = value; }
    }

    bool IsReverseType(ElementsNames type)
    {
        switch (element)
        {
            case ElementsNames.LIGHT:
                if(type == ElementsNames.CHAOS)
                {
                    return true;
                }
                return false;
            case ElementsNames.DARK:
                if(type == ElementsNames.LIGHT)
                {
                    return true;
                }
                return false;
            case ElementsNames.CHAOS:
                if(type == ElementsNames.DARK)
                {
                    return true;
                }
                return false;
            default:
                return false;
        }
    }

    void ManageBallMovement()
    {
        Vector3 refPosition;
        switch (currentPlayerTarget)
        {
            case PlayerPosition.RIGHT:
                refPosition = rightPlayerTransform.position;
                break;
            case PlayerPosition.LEFT:
                refPosition = leftplayerTransform.position;
                break;
            default:
                refPosition = rightPlayerTransform.position;
                break;
        }

        float distance = Vector3.Distance(refPosition, transform.position);
        speed = Mathf.Lerp(speed, speed * maxSpeedAugmentationMult, (distanceBetweenPlayers - distance) / distanceBetweenPlayers);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Spell")
        {
            Spell sp = other.gameObject.GetComponent<Spell>();
            if(sp.moveright != GoRight)
            {
                //if(IsReverseType(sp.type))
                //{
                    ManageBallMovement();   
                //}
            }
        }
    }
   
}
