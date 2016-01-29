using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public int playerId = 0;
    public float startHealth = 100.0f;
    public float startMana = 100.0f;

    private float health;
    private float mana;

	// Use this for initialization
    void Start()
    {
        health = startHealth;
        mana = startMana;
    }	
	
}
