using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public int PlayerPosition;
    public float startHealth = 100.0f;
    public float startMana = 100.0f;

    public GameObject sequences;

	// Use this for initialization
    void Start()
    {
        KeySequencer[] sequencesTab = sequences.GetComponentsInChildren<KeySequencer>();
    }	
	
}

public enum PlayerPosition
{
    RIGHT,
    LEFT
}
