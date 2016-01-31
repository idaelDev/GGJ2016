using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public int PlayerPosition;
    public float startHealth = 100.0f;
    public float startMana = 100.0f;

    public Sprite looseSprite;

    public GameObject sequences;

	// Use this for initialization
    void Start()
    {
        KeySequencer[] sequencesTab = sequences.GetComponentsInChildren<KeySequencer>();
    }	
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            GetComponent<Animator>().SetTrigger("Die");
        }
    }
}

public enum PlayerPosition
{
    RIGHT,
    LEFT
}

