using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

    public SpellsEnum name;
    public SpellsEnum blocking;
    public KeySequencer sequencer;

    void Start()
    {
        sequencer.SequenceValidEvent += LaunchSpell;
    }

    void LaunchSpell()
    {
        Debug.Log("Spell : " + name.ToString());
    }

}
