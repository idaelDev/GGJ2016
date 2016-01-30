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

	// begin stuff
	private bool beginBool = true;
	public float timeToBegin;
	private float beginY;
	private float timer;
	private bool endOnce = false;
	public float speedFadeOutVolume;
	private AudioSource beginAudioClip;
	public  BubbleManagerScript bubbleManager;

    void Start()
    {
        speed = initialSpeed;
        distanceBetweenPlayers = Vector3.Distance(rightPlayerTransform.position, leftplayerTransform.position);
		beginY = transform.position.y;
		beginAudioClip = GetComponent<AudioSource> ();
    }

    void Update()
    {
		if (!beginBool) {
			Vector3 move = moveDirection * speed * Time.deltaTime;
			if (!goRight) {
				move *= -1;
			}
			transform.position = transform.position + move;
            transform.Rotate(new Vector3(0,0,100) * speed * Time.deltaTime * ((goRight) ? -1 : 1));
		} else {
			timer += Time.deltaTime;
			if(timer >= timeToBegin){
				if(!endOnce){
					transform.position = new Vector3(transform.position.x, -2, transform.position.z);
					endOnce = true;
				}
				else{
					beginAudioClip.volume -= Time.deltaTime * speedFadeOutVolume;
					if(beginAudioClip.volume == 0){ 
						beginBool = false;
					}
				}
			}
			else{
				transform.position = new Vector3(transform.position.x, Mathf.Lerp(beginY, -2, timer/timeToBegin), transform.position.z);
			}
		}
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

    void SetType()
    {
        int rand = Random.Range(0, 3);
        element = (ElementsNames)rand;
    }

    void ManageBallMovement()
    {
        Vector3 refPosition;
        switch (currentPlayerTarget)
        {
            case PlayerPosition.RIGHT:
                refPosition = rightPlayerTransform.position;
                goRight = false;
                currentPlayerTarget = PlayerPosition.LEFT;
                break;
            case PlayerPosition.LEFT:
                refPosition = leftplayerTransform.position;
                currentPlayerTarget = PlayerPosition.RIGHT;
                goRight = true;
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
                if(IsReverseType(sp.type))
                {
                    ManageBallMovement();
                    SetType();
                    other.gameObject.GetComponent<PooledObject>().OriginPool.HideObject(other.gameObject.GetComponent<PooledObject>());
                }
            }
        }
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player " + currentPlayerTarget.ToString() + " Win !");
			if(currentPlayerTarget == PlayerPosition.LEFT){
				bubbleManager.setWinPlayer(1);
			}
			else{
				bubbleManager.setWinPlayer(2);
			}
			/// do stuff
            Destroy(gameObject);
        }
    }
}
