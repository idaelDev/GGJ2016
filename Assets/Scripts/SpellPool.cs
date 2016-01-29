using UnityEngine;
using System.Collections;


public class SpellPool : ObjectPool {

    public KeySequencer sequencer;

    protected void Start()
    {
        base.Start();
        sequencer.SequenceValidEvent += LaunchSpell;
    }

    void LaunchSpell()
    {
        GetObject();
    }

}
